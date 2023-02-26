using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{

    public class StudentV2
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public bool IsActive { get; set; }

        public int? StudentRating { get; set; }

        public string Description { get; set; }

       
        public string ParentName { get; set; }
        public string ParentAddress { get; set; }

        public string ParentIDNumber { get; set; }

        public string ParentPhoneNumber { get; set; }
        public string ParentEmail { get; set; }
    }
}
