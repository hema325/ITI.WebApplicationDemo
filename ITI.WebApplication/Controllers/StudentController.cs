using ITI.WebApplication.Models;
using ITI.WebApplication.RepositoryPattern.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITI.WebApplication.Controllers
{
    public class StudentController : Controller
    {
        private readonly IDepartmentRepository _departments;
        private readonly IStudentRepository _students;

        public StudentController(IDepartmentRepository departments, IStudentRepository students)
        {
            _departments = departments;
            _students = students;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            return View(await _students.GetAllAsync()) ;
        }

        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
            ViewBag.Departments = (await _departments.GetAllAsync()).Select(d => new SelectListItem { Text = d.Name, Value = d.Id.ToString() });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Student student)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = (await _departments.GetAllAsync()).Select(d => new SelectListItem { Text = d.Name, Value = d.Id.ToString() });
                return View(student);
            }

            await _students.CreateAsync(student);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(int id)
        {
            ViewBag.Departments = (await _departments.GetAllAsync()).Select(d => new SelectListItem { Text = d.Name, Value = d.Id.ToString() });
            return View(await _students.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(Student student)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = (await _departments.GetAllAsync()).Select(d => new SelectListItem { Text = d.Name, Value = d.Id.ToString() });
                return View(student);
            }

            await _students.UpdateAsync(student);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> DetailsAsync(int id)
        {
            return View(await _students.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var student = await _students.GetByIdAsync(id);

            await _students.DeleteAsync(student);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> IsNameValid(int id, string name)
        {
            var student = await _students.GetByNameAsync(name);
            return Ok(student == null || student.Id == id);
        }
    }
}
