using ShoppingCart.Infrastructure.Repositories;

namespace ShoppingCart.Infrastructure.UoW
{
    public interface IUoW
    {
        bool Commit();
        IRepository<T> GetRepository<T>() where T : class;
    }
}
