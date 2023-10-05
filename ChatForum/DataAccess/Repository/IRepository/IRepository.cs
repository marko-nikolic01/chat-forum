using System.Linq.Expressions;

namespace DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string? includedProperties = null);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includedProperties = null);
        void Add(T entity);
        void Remove(T entity);
    }
}