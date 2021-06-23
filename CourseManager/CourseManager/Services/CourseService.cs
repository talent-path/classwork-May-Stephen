﻿using System;
using System.Collections.Generic;
using System.Linq;
using CourseManager.Exceptions;
using CourseManager.Models;
using CourseManager.Repos;

namespace CourseManager.Services
{
    public class CourseService
    {
        InMemCourseRepo _courseRepo = new InMemCourseRepo();
        ITeacherRepo _teacherRepo = new DbTeachersRepo();
        InMemStudentRepo _studentRepo = new InMemStudentRepo();

        public List<Course> GetAll()
        {
            return _courseRepo.GetAll();
        }

        public List<Teacher> GetAllTeachers()
        {
            return _teacherRepo.GetAll();
        }

        public List<Student> GetAllStudents()
        {
            return _studentRepo.GetAll();
        }

        public Course GetById(int id)
        {
            Course toReturn = _courseRepo.GetById(id);

            if( toReturn == null)
            {
                throw new CourseNotFoundException($"No course has an id of {id}.");
            }

            return toReturn;
        }


        public Teacher GetTeacherById(int id)
        {
            Teacher toReturn = _teacherRepo.GetById(id);

            if (toReturn == null)
            {
                throw new TeacherNotFoundException($"No teacher has an id of {id}.");
            }

            return toReturn;
        }

       

        internal void DeleteTeacher(Teacher t)
        {
            _teacherRepo.DeleteTeacher(t);
        }

        public void DeleteStudent(Student s)
        {
            _studentRepo.DeleteStudent(s);
        }

        public Student GetStudentById(int id)
        {
            return _studentRepo.GetById(id);
        }

        public void DeleteCourse(Course c)
        {
            _courseRepo.DeleteCourse(c);

            List<Course> allCourses = _courseRepo.GetAll();
            List<Student> allStudents = _studentRepo.GetAll();
            List<Teacher> allTeachers = _teacherRepo.GetAll();

            foreach (Student s in allStudents)
            {
                s.Courses.RemoveAll(course => course.Id == c.Id);
            }
            foreach (Teacher t in allTeachers)
            {
                t.Courses.RemoveAll(course => course.Id == c.Id);
            }
        }

        public void EditCourse(Course toEdit)
        {
            _courseRepo.Edit(toEdit);

            //may need to fix all students and teachers
            //because of stupid in-mem relationships

            List<Course> allCourses = _courseRepo.GetAll();
            List<Student> allStudents = _studentRepo.GetAll();
            List<Teacher> allTeachers = _teacherRepo.GetAll();

            foreach (Student anyStudent in allStudents)
            {
                anyStudent.Courses =
                    allCourses.Where(
                        course => course.ClassStudents.Any(
                            classStudent => classStudent.Id == anyStudent.Id)).ToList();


            }
            foreach (var anyTeacher in allTeachers)
            {
                anyTeacher.Courses = allCourses
                    .Where(course => course.ClassTeacher.Id == anyTeacher.Id)
                    .ToList();
            }
        }

        public void EditTeacher(Teacher toEdit)
        {
            _teacherRepo.Edit(toEdit);
        }
    }
}
