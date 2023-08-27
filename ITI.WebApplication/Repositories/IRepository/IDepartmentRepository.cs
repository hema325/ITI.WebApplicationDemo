using ITI.WebApplication.Models;

namespace ITI.WebApplication.RepositoryPattern.IRepository
{
    public interface IDepartmentRepository
    {
        Task CreateAsync(Department department);
        Task DeleteAsync(Department department);
        Task<List<Department>> GetAllAsync();
        Task<Department> GetByIdAsync(int id);
        Task<Department> GetByNameAsync(string name);
        Task UpdateAsync(Department department);
    }
}
