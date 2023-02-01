using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class StudentService : IStudentService
    {
        private readonly IStudentDal _studentDal;

        public StudentService(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        public void TAdd(Student t)
        {
           _studentDal.Insert(t);
        }

        public void TDelete(Student t)
        {
            _studentDal.Delete(t);
        }

        public Student TGetById(int id)
        {
            return _studentDal.GetById(id);
        }

        public List<Student> TGetList()
        {
            return _studentDal.GetList();
        }

        public void TUpdate(Student t)
        {
            _studentDal.Update(t);
        }
    }
}
