using System;
using System.Collections.Generic;
using System.Linq;
using CourseManager.Exceptions;
using CourseManager.Models;
using CourseManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseManager.Controllers
{
    public class CourseController : Controller
    {
        CourseService _service = new CourseService();

        /// <summary>
        /// List all courses.
        /// </summary>
        /// <returns>Index page</returns>
        public IActionResult Index()
        {
            //1. ask service for the list of courses
            var courses = _service.GetAll();
            //2. send list off to view
            return View(courses);
        }

        public IActionResult Details( int? id )
        {
            if (id != null)
            {
                try
                {
                    Course toDisplay = _service.GetById(id.Value);
                    List<StudentCourse> studentCourses = _service.GetStudentCoursesByCourseId(id.Value);
                    List<Student> students = new List<Student>();
                    for (int i = 0;i<studentCourses.Count;++i)
                    {
                        Student student = _service.GetStudentById(studentCourses[i].StudentId);
                        students.Add(student);
                    }
                    toDisplay.ClassStudents = students;
                    return View(toDisplay);

                }
                catch ( CourseNotFoundException ex)
                {
                    return NotFound(ex.Message);
                }
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<Teacher> allTeachers = _service.GetAllTeachers();
            List<Student> allStudents = _service.GetAllStudents();
            AddCourseViewModel vm = new AddCourseViewModel
            {
                ToAdd = new Course(),
                AllTeachers = allTeachers,
                AllStudents = allStudents
                
            };

            return View(vm);

        }

        [HttpPost]
        public IActionResult Add(AddCourseViewModel vm)
        {
            vm.AllStudents = _service.GetAllStudents();
            if (vm.ToAdd.ClassTeacher.Id != null)
            {
                Teacher fullyHydratedTeacher
                    = _service.GetTeacherById(vm.ToAdd.ClassTeacher.Id.Value);

                vm.ToAdd.ClassTeacher = fullyHydratedTeacher;

               int id = _service.AddCourse(vm.ToAdd);
                vm.ToAdd.Id = id;
                _service.AddStudentCourses(vm);
                return RedirectToAction("Index");
            }

            return BadRequest();

        }

        [HttpGet]
        public IActionResult Edit( int? id)
        {
            if (id != null)
            {
                try
                {
                    Course toDisplay = _service.GetById(id.Value);
                    List<Teacher> allTeachers = _service.GetAllTeachers();
                    List<Student> allStudents = _service.GetAllStudents();

                    EditCourseViewModel vm = new EditCourseViewModel {
                        ToEdit = toDisplay,
                        AllStudents = allStudents,
                        AllTeachers = allTeachers
                    };

                    return View(vm);

                }
                catch (CourseNotFoundException ex)
                {
                    return NotFound(ex.Message);
                }
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Edit( EditCourseViewModel vm)
        {
            //the incoming course model and attached teacher models will be
            //incomplete

            //we need to "fully hydrate" these objects by pulling the complete
            //versions from our dao using the ids that came back

            if (vm.ToEdit.ClassTeacher.Id != null)
            {

               

                

                //vm.ToEdit.ClassTeacher = fullyHydratedTeacher;
                //vm.ToEdit.ClassStudents = fullyHydratedStudents;

                _service.EditCourse(vm.ToEdit);
                _service.AddStudentCourses(vm);

                return RedirectToAction("Index");
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult Delete(Course course)
        {
            if (course.Id != null)
            {
                try
                {
                    Course toDelete = _service.GetById(course.Id.Value);
                    return View(toDelete);
                }
                catch(CourseNotFoundException ex)
                {
                    return NotFound(ex.Message);
                }
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if(id != null)
            {
                _service.DeleteCourse(id.Value);
                return RedirectToAction("Index");
            }

            return BadRequest();
        }

    }
}
