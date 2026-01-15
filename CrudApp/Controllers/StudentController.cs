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
        //public IActionResult Index()
        //{
        //    IEnumerable<Student> students = _context.Students.ToList();
        //    return View(students);
        //}

        // CREATE
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // CREATE
        [HttpPost]
        public IActionResult Create([Bind("Name, Roll, Class, Email")] Student model)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(model);
                _context.SaveChanges();
                TempData["Notification"] = "Student Created Successfully";
                TempData["NotificationType"] = "Success";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // EDIT
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                return View(student);
            }
        }

        // EDIT
        [HttpPost]
        public IActionResult Edit([Bind("Id, Name, Roll, Class, Email")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                _context.SaveChanges();
                TempData["Notification"] = "Student Updated Successfully";
                TempData["NotificationType"] = "Success";
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // DELETE
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            else 
            {
                return View(student);
            }
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
                TempData["Notification"] = "Student Deleted Successfully";
                TempData["NotificationType"] = "Success";
            }
            return RedirectToAction("Index");

        }

        public IActionResult Index(string searchString)
        {
            var students = _context.Students.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                students = students.Where(s =>
                    s.Name.Contains(searchString) ||
                    s.Email.Contains(searchString) ||
                    s.Roll.ToString().Contains(searchString)
                );
            }

            return View(students.ToList());
        }



    }
}
