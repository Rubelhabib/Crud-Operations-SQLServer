using CrudApp.Data;
using CrudApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> students = _context.Students.ToList();
            return View(students);
        }
    }
}
