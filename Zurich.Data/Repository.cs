using DapperExtensions;
using System.Configuration;
using System.Data;
using Zurich.Domain.Repositories.Interface;

namespace Zurich.Infrastructure.Data
{
    public abstract class Repository<T, TKey> : IRepository<T, TKey> where T : class
    {
        private readonly IDbConnection _connection;
        protected Repository(IDbConnection connection)
        {
            _connection = connection;
        }
        public void Add(T item)
        {
            // TKey success = default(TKey);
            T state = null;

            _connection.Insert(item);

            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["zurich"].ConnectionString;
        }
        public bool Update(T item)
        {
            bool success;
            T state = _connection.Get<T>(item);
            success = _connection.Update(item);

            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["zurich"].ConnectionString;
            return success;
        }

    }
}
