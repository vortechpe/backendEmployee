using Employee.Domain.Common;
using Employee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Employee.Domain.Intefaces
{
    public interface IEmployeeRepository
    {
        Task<Employees> GetByIdAsync(int id);
        Task<Employees> GetByDocumentNumber(string documentNumber);
        Task<PagedResult<Employees>> GetAllAsync(
            int pageNumber,
            int pageSize,
            string searchTerm = null);
        Task AddAsync(Employees employee);
        Task UpdateAsync(Employees employee);
        Task DeleteAsync(Employees employee);
    }
}
