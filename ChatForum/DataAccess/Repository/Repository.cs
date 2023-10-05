using DataAccess.Context;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public IEnumerable<T> GetAll(string? includedProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (!string.IsNullOrEmpty(includedProperties))
            {
                foreach (string property in includedProperties.Split(','))
                {
                    query = query.Include(property);
                }
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includedProperties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includedProperties))
            {
                foreach (string property in includedProperties.Split(','))
                {
                    query = query.Include(property);
                }
            }
            return query.FirstOrDefault();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
