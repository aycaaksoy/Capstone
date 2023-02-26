using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public interface IGameRepository : IRepository<Game>
    {
        IEnumerable<Game> GetUnapprovedItems();
    }
}
