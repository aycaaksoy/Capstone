using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context: IdentityDbContext<AppUser,AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             
            optionsBuilder.UseSqlServer("Server=DESKTOP-60DI5A8;Database=DbStudentManagementSystem3; integrated security=true;");
        }
        public DbSet<Trainer> trainers { get; set; }
        
        
        public DbSet<StudentV2> studentsv2 { get; set; }
        public DbSet<Course> courses { get; set; }
        
        public DbSet<Announcement> announcements { get; set; }
        public DbSet<Game> games { get; set; }
    }
}
                    