using System;
using CourseManager.Exceptions;
using CourseManager.Models;
using CourseManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseManager.Controllers
{
    public class StudentController : Controller
    {
        CourseService _service = new CourseService();


        public IActionResult Index()
        {
            var students = _service.GetAllStudents();
            return View(students);
        }

        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                try
                {
                    Student toDisplay = _service.GetStudentById(id.Value);
                    return View(toDisplay);
                }
                catch (StudentNotFoundException e)
                {
                    return NotFound(e.Message);
                }
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                try
                {
                    Student toDelete = _service.GetStudentById(id.Value);
                    return View(toDelete);
                }
                catch (StudentNotFoundException ex)
                {
                    return NotFound(ex.Message);
                }
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult Delete(Student s)
        {
            _service.DeleteStudent(s);
            return RedirectToAction("Index");
        }
    }
}
