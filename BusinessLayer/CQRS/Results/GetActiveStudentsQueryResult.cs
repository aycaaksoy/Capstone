using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Results
{
    public class GetActiveStudentsQueryResult 
    {
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
