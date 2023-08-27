using ITI.WebApplication.Data;
using ITI.WebApplication.Models;
using ITI.WebApplication.RepositoryPattern.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ITI.WebApplication.RepositoryPattern.Repository
{
    public class DepartmentRepository: IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetAllAsync()
            => await _context.Departments.ToListAsync();

        public async Task<Department> GetByIdAsync(int id)
            => await _context.Departments.FirstOrDefaultAsync(s => s.Id == id);

        public async Task<Department> GetByNameAsync(string name)
            => await _context.Departments.FirstOrDefaultAsync(s => s.Name == name);

        public async Task CreateAsync(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Department department)
        {
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Department department)
        {
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
        }
    }
}
