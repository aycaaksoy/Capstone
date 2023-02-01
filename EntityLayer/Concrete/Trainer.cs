using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Trainer
    {
        [Key]
        public int TrainerId { get; set; }

        [Required]
        public string TrainerName { get; set; }

        public string TrainerDescription { get; set; }

        [Required]
        [Phone]
        public string TrainerPhoneNumber { get; set; }

        [Required]
        public bool TrainerIsActive { get; set; }

        public ICollection<TrainerCourse> TrainerCourses { get; set; } = new List<TrainerCourse>();

        public int UserID { get; set; }
    }
    public class TrainerCourse
    {
        [Key]
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }

        public int CourseId { get; set; }
        public Course course { get; set; }
    }
}
