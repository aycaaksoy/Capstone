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

     
        public string TrainerName { get; set; }

        public string TrainerDescription { get; set; }

        
        public string TrainerPhoneNumber { get; set; }

        public bool TrainerIsActive { get; set; }

    }
  
}
