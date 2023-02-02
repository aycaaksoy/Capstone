using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.CQRS.Handlers;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DTO.AppUserDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DIContainer
{
    public static class Extensions
    {
        
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IStudentDal,EFStudentDal>();

            services.AddScoped<IStudentV2Service, StudentV2Service>();
            services.AddScoped<IStudentV2Dal, EFStudentV2Dal>();

            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICourseDal, EFCourseDal>();

            services.AddScoped<IAnnouncementService, AnnouncementService>();
            services.AddScoped<IAnnouncementDal, EFAnnouncementDal>();

            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMiscellaneousService, MiscellaneousService>();
            services.AddScoped<GetActiveStudentsHandlers>();
           
            
        }
    }
}
