using System;
using System.Collections.Generic;

namespace CourseManager.Models
{
    public class EditTeacherViewModel
    {
        public Teacher toEdit { get; set; }
        public List<Course> allCourses { get; set; }
        public int[] SelectedCourseIds { get; set; }
    }
}
