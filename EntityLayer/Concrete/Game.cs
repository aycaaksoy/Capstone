using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{

    public class Game
    {
        [Key]
      
        public int Id { get; set; }
        public string PGN { get; set; }
        public string username { get; set; }
        public bool Approved { get; set; }
    }
}
