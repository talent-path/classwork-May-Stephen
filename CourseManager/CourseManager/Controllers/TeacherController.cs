using System;
using System.Collections.Generic;
using System.Linq;
using CourseManager.Exceptions;
using CourseManager.Models;
using CourseManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseManager.Controllers
{
    public class TeacherController : Controller
    {
        CourseService _service = new CourseService();


        public IActionResult Index()
        {
            var teachers = _service.GetAllTeachers();
            return View(teachers);
        }

        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                try
                {
                    Teacher toDisplay = _service.GetTeacherById(id.Value);
                    return View(toDisplay);
                }
                catch (TeacherNotFoundException e)
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
                    Teacher toDelete = _service.GetTeacherById(id.Value);
                    return View(toDelete);
                }
                catch (TeacherNotFoundException ex)
                {
                    return NotFound(ex.Message);
                }
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult Delete(Teacher t)
        {
            _service.DeleteTeacher(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                try
                {
                    Teacher toDisplay = _service.GetTeacherById(id.Value);
                    List<Course> courses = toDisplay.Courses;

                    EditTeacherViewModel tm = new EditTeacherViewModel
                    {
                        toEdit = toDisplay,
                        allCourses = courses
                    };
                    return View(tm);
                }
                catch (TeacherNotFoundException e)
                {
                    return NotFound(e.Message);
                }
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Edit(EditTeacherViewModel tm)
        {
            if (tm.toEdit.Id != null)
            {
                List<Course> fullyHydratedCourses =
                    tm.SelectedCourseIds.Select(id => _service.GetById(id)).ToList();

                tm.toEdit.Courses = fullyHydratedCourses;

                _service.EditTeacher(tm.toEdit);

                return RedirectToAction("Index");
            }

            return BadRequest();
        }
    }
}
