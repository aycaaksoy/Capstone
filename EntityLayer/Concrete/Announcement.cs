using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Announcement
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime TimePosted { get; set; }
    }
}
