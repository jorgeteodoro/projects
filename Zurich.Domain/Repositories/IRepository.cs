
namespace Zurich.Domain.Repositories.Interface
{
    public interface IRepository<in T, TKey> where T : class
    {
        void Add(T item);
        bool Update(T item);
        
    }
}
