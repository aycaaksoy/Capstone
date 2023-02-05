using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public bool CourseIsActive { get; set; }

        public DateTime DateCreated { get; set; }

        public String LectureTimeDay { get; set; }
        public DateTime LectureTimeHours { get; set; }
        public DateTime LatestAddedStudentDate { get; set; }

        
 
    }
}
