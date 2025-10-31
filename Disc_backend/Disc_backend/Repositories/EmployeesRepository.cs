using Disc_backend.Models;
using Disc_backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Disc_backend.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {

        private readonly DiscProfileDbContext _context;
        private readonly DbSet<Employee> _dbSet;

        public EmployeesRepository(DiscProfileDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Employee>();
        }


        public async Task<List<Employee>?> GetAll(int? departmentId, int? positionId)
        {
            List<Employee> employees = await _dbSet.ToListAsync();
            if (employees == null || employees.Count == 0)
            {
                return null;
            }
            else if (departmentId != null)
            {
                employees = employees.FindAll(employee => employee.DepartmentId == departmentId);
            }
            else if (positionId != null)
            {
                employees = employees.FindAll(employee => employee.PositionId == positionId);
            }
            return employees;
        }


    }
}
