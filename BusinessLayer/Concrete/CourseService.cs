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
    public class CourseService :ICourseService
    {
        private readonly ICourseDal _courseDal;

        public CourseService(ICourseDal courseDal)
        {
           _courseDal= courseDal;
        }

        public void TAdd(Course t)
        {
            _courseDal.Insert(t);
        }

        public void TDelete(Course t)
        {
            _courseDal.Delete(t);
        }

        public Course TGetById(int id)
        {
            return _courseDal.GetById(id);  
        }

        public List<Course> TGetList()
        {
            return _courseDal.GetList();
        }

        public void TUpdate(Course t)
        {
            _courseDal.Update(t);
        }
    }
}
