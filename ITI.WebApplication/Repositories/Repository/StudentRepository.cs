using ITI.WebApplication.Data;
using ITI.WebApplication.Models;
using ITI.WebApplication.RepositoryPattern.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ITI.WebApplication.RepositoryPattern.Repository
{
    public class StudentRepository: IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllAsync()
            => await _context.Students.ToListAsync();

        public async Task<Student> GetByIdAsync(int id)
            => await _context.Students.Include(s => s.Department).FirstOrDefaultAsync(s => s.Id == id);

        public async Task<Student> GetByNameAsync(string name)
            => await _context.Students.Include(s => s.Department).FirstOrDefaultAsync(s => s.Name == name);

        public async Task CreateAsync(Student student)
        { 
             _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}
