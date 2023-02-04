using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GetActiveStudentsListDto
    {
        public IEnumerable<StudentV2> Students { get; set; }
        public int Count { get; set; }
    }
}
