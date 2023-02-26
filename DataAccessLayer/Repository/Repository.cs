using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly IdentityDbContext _context;
        protected readonly DbSet<T> DbSet;

        public Repository(IdentityDbContext context)
        {
            _context = context;
            DbSet = _context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            DbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

        }
        public virtual void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return DbSet.AsEnumerable();
        }

        public virtual T GetById(int id)
        {
            return DbSet.Find(id);
        }
    }
}
