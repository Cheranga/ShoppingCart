using System.Data.Entity;
using ShoppingCart.Infrastructure.Repositories;

namespace ShoppingCart.Infrastructure.RepositoryProvider
{
    public interface IRepositoryProvider
    {
        DbContext Context { get; set; }
        IRepository<T> GetRepository<T>() where T : class;
        void SetRepository<T>(IRepository<T> repository) where T : class;

    }
}
