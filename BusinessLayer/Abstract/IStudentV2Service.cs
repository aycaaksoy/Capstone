using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IStudentV2Service : IGenericService<StudentV2>
    {
        public List<StudentV2> StudentList();

       
    }
}
