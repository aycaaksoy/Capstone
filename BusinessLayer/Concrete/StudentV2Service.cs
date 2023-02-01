using BusinessLayer.Abstract;
using ClosedXML.Excel;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class StudentV2Service: IStudentV2Service
    {
        private readonly IStudentV2Dal _studentv2Dal;
        

        public StudentV2Service(IStudentV2Dal studentv2Dal)
        {
            _studentv2Dal = studentv2Dal;
           
        }

        public void TAdd(StudentV2 t)
        {
            _studentv2Dal.Insert(t);
        }

        public void TDelete(StudentV2 t)
        {
            _studentv2Dal.Delete(t);
        }

        public StudentV2 TGetById(int id)
        {
            return _studentv2Dal.GetById(id);
        }

        public List<StudentV2> TGetList()
        {
            return _studentv2Dal.GetList();
        }

        public void TUpdate(StudentV2 t)
        {
            _studentv2Dal.Update(t);
        }
        public List<StudentV2> StudentList()
        {
            List<StudentV2> students = null;
            using (var context = new Context())
            {
                students = context.studentsv2.Select(x => new StudentV2
                {
                    StudentId = x.StudentId,
                    IsActive = x.IsActive,
                    StudentRating = x.StudentRating,
                    Description = x.Description,
                    UserID = x.UserID,
                    ParentName = x.ParentName,
                    ParentAddress = x.ParentAddress,
                    ParentIDNumber = x.ParentIDNumber,
                    ParentPhoneNumber = x.ParentPhoneNumber,
                    ParentEmail = x.ParentEmail
                }).ToList();
            }
            return students;
        }
        
    }
}
