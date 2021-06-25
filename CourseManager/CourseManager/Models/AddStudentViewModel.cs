using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Models
{
    public class AddStudentViewModel
    {
        public Student ToAdd { get; set; }

        public List<Course> AllCourses { get; set; }

        public List<int> CurCourseIds { get; set; }
    }
}
