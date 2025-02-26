using Employee.Domain.Common;
using Employee.Domain.Entities;
using Employee.Domain.Intefaces;
using Employee.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task AddAsync(Employees employee)
        {
            try
            {
                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();

            }
            catch (Exception e )
            {

                throw e;
            }
            
        }

        public async Task DeleteAsync(Employees employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<Employees>> GetAllAsync(
    int pageNumber,
    int pageSize,
    string searchTerm)
        {
            IQueryable<Employees> query = _context.Employees
                .Include(e => e.Position)
                .Include(e => e.Afp)
                .Where(e => e.IsActive) // Filtrar solo empleados activos
                .OrderByDescending(e => e.CreatedAt); // Ordenar por fecha de creación descendente

            // Filtro de búsqueda
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(e =>
                    e.FirstName.Contains(searchTerm) ||
                    e.LastName.Contains(searchTerm) ||
                    e.Position.Name.Contains(searchTerm) ||
                    e.Afp.Name.Contains(searchTerm));
            }

            int totalCount = await query.CountAsync();

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Employees>(items, totalCount, pageNumber, pageSize);
        }


        public async Task<Employees> GetByDocumentNumber(string documentNumber)
        {
            return await _context.Employees
               .FirstOrDefaultAsync(e => e.documentoNumber.Equals(documentNumber));
        }

        public async Task<Employees> GetByIdAsync(int id)
        {
            return await _context.Employees
                .Include(e => e.Position)
                .Include(e => e.Afp)
                .FirstOrDefaultAsync(e => e.EmployeeId == id);

        }

        public async Task UpdateAsync(Employees employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}
