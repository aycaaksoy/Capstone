using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        
        public GameRepository(IdentityDbContext context) : base(context) { }
       
        public IEnumerable<Game> GetUnapprovedItems()
        {
            return DbSet.Where(i => !i.Approved).ToList();
        }
    }
}
