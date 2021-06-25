using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseManager.Models;

namespace CourseManager.Repos
{
    interface IStudentCourseRepo
    {
        void Add(StudentCourse toAdd);

        void DeleteByStudentId(StudentCourse toDelete);

        void DeleteByCourseId(StudentCourse toDelete);
        List<StudentCourse> GetStudentCoursesByCourseId(int value);
    }
}
