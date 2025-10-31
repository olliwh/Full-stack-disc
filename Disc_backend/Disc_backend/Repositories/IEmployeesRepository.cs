using Disc_backend.Models;

namespace Disc_backend.Repositories
{
    public interface IEmployeesRepository
    {
        Task<List<Employee>?> GetAll(int? departmentId, int? positionId);
    }
}