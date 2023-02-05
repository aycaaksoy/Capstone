using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.IO;

namespace Capstone.Areas.Admin.Controllers
{
    [Area("Admin")]

    [AllowAnonymous]
    [Authorize(Roles = "Admin")]

    public class HomeController : Controller
    {
       
        
        private readonly IStudentV2Service _studentV2Service;
        private readonly IAnnouncementService _announcementService;
        public HomeController(  IAnnouncementService announcementService, IStudentV2Service studentV2Service)
        {
           
            _announcementService = announcementService;
            _studentV2Service = studentV2Service;
        }

        [Route("Admin/Home/Dashboard")]
        [HttpGet]
        public IActionResult Dashboard()
        {
            var values = _studentV2Service.TGetList();
            return View(values);
        }

        public IActionResult DashboardWidgetsPartial()
        {
            return PartialView();
        }

        public IActionResult GetActiveStudentPartial()
        {
            
            return PartialView();
        }

        [Route("Admin/Home/Announcement")]
        [HttpGet]
        public IActionResult Announcement()
        {
            var values = _announcementService.TGetList();
            return View(values);
        }

        public IActionResult DeleteAnnouncement(int id)
        {
           
            var values = _announcementService.TGetById(id);
            _announcementService.TDelete(values);
            return RedirectToAction("Announcement");
        }

        [Route("Admin/Home/UpdateAnnouncement/{id}")]
        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)
        {
            var values = _announcementService.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateAnnouncement(Announcement announcement)
        {
            var values = _announcementService.TGetById(announcement.PostId);
            announcement.Title = values.Title;
            announcement.TimePosted = values.TimePosted;
            announcement.Body= values.Body;
            _announcementService.TUpdate(values);
            return RedirectToAction("Announcement");
        }

        [Route("Admin/Home/PostAnnouncement")]
        [HttpGet]
        public IActionResult PostAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PostAnnouncement (Announcement announcement)
        {
            AnnouncementValidator annoncementValidator = new AnnouncementValidator();
            ValidationResult result = annoncementValidator.Validate(announcement);
            if (result.IsValid)
            {
                _announcementService.TAdd(announcement);
                return RedirectToAction("Announcement");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }

            return View();
        }

        [Route("Admin/Home/AddStudent")]
        [HttpGet]
        public IActionResult AddStudent() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(StudentV2 student)
        {
            StudentV2Validator studentValidator = new StudentV2Validator();
            ValidationResult result = studentValidator.Validate(student);
            if (result.IsValid)
            {
                _studentV2Service.TAdd(student);
                return RedirectToAction("Dashboard");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            
            return View();
        }

        public IActionResult DeleteStudent(int id)
        {
            var values = _studentV2Service.TGetById(id);
            _studentV2Service.TDelete(values);
            return RedirectToAction("Dashboard");
        }

        public IActionResult DownloadStudentsExcel()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Students List");
                workSheet.Cell(1, 1).Value = "StudentId";
                workSheet.Cell(1, 2).Value = "StudentName";
                workSheet.Cell(1, 3).Value = "IsActive";
                workSheet.Cell(1, 4).Value = "StudentRating";
                workSheet.Cell(1, 5).Value = "Description";
               
                workSheet.Cell(1, 6).Value = "ParentName";
                workSheet.Cell(1, 7).Value = "ParentAddress";
                workSheet.Cell(1, 8).Value = "ParentIDNumber";
                workSheet.Cell(1, 9).Value = "ParentPhoneNumber";
                workSheet.Cell(1, 10).Value = "ParentEmail";

                int rowCount = 2;
                var StudentList = _studentV2Service.StudentList();
                foreach (var item in StudentList)
                {
                    workSheet.Cell(rowCount, 1).Value = item.StudentId;
                    workSheet.Cell(rowCount, 2).Value = item.StudentName;
                    workSheet.Cell(rowCount, 3).Value = item.IsActive;
                    workSheet.Cell(rowCount, 4).Value = item.StudentRating;
                    workSheet.Cell(rowCount, 5).Value = item.Description;
                   
                    workSheet.Cell(rowCount, 6).Value = item.ParentName;
                    workSheet.Cell(rowCount, 7).Value = item.ParentAddress;
                    workSheet.Cell(rowCount, 8).Value = item.ParentIDNumber;
                    workSheet.Cell(rowCount, 9).Value = item.ParentPhoneNumber;
                    workSheet.Cell(rowCount, 10).Value = item.ParentEmail;
                    rowCount++;
                }
                using(var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "studentList.xlsx");
                }
            }
        }
    }
}
