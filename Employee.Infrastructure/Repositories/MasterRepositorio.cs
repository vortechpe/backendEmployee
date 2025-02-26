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
    public class MasterRepositorio : IMasterRepository
    {
        private readonly ApplicationDbContext _context;

        public MasterRepositorio(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<List<Afp>> getAfp()
        {
            return await _context.Afps.ToListAsync();
        }

        public async Task<List<Position>> getPosition()
        {
            return await _context.Positions.ToListAsync();
        }
    }
}
