using ITI.WebApplication.Models;
using ITI.WebApplication.RepositoryPattern.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ITI.WebApplication.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departments;

        public DepartmentController(IDepartmentRepository departments)
        {
            _departments = departments;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            return View(await _departments.GetAllAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Department model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _departments.CreateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(int id)
        {
            return View(await _departments.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(Department model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _departments.UpdateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> DetailsAsync(int id)
        {
            return View(await _departments.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var department = await _departments.GetByIdAsync(id);
            _departments.DeleteAsync(department);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> IsNameValid(int id, string name)
        {
            var department = await _departments.GetByNameAsync(name);
            return Ok(department == null || department.Id == id);
        }
    }
}
