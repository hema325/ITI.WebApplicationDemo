using ITI.WebApplication.Models;

namespace ITI.WebApplication.RepositoryPattern.IRepository
{
    public interface IStudentRepository
    {
        Task CreateAsync(Student student);
        Task DeleteAsync(Student student);
        Task<List<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);
        Task<Student> GetByNameAsync(string name);
        Task UpdateAsync(Student student);
    }
}
