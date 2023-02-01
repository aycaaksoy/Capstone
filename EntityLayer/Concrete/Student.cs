using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        public string StudentName { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public int? StudentRating { get; set; }

        public string Description { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

        public int UserID { get; set; }
  
        public int ParentId { get; set; }

     
        public string ParentName { get; set; }

       
        public string ParentAddress { get; set; }

      
        public string ParentIDNumber { get; set; }

     
        public string ParentPhoneNumber { get; set; }

        
        public string ParentEmail { get; set; }

    }
    public class StudentCourse
    {
        [Key]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
