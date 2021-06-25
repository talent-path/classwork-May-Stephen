using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManager.Models
{
    public class Teacher
    {
        [Column("Id")]
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public List<Course> Courses { get; set; } = new List<Course>();

        public Teacher() { }

        public Teacher( Teacher that)
        {
            this.Id = that.Id;
            this.Name = that.Name;
            this.Courses = that.Courses;
        }
    }
}
