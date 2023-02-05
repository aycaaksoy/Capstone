using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Results
{
    public class ActiveStudentCountResult
    {
        public ActiveStudentCountResult(int count)
        {
            Count = count;
        }
        public ActiveStudentCountResult() { }
        
        public int Count { get; set; }
    }
}
