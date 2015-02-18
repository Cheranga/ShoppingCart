using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.DAL.Factories;
using ShoppingCart.Infrastructure.Repositories;
using ShoppingCart.Infrastructure.RepositoryProvider;

namespace ShoppingCart.DAL.RepositoryProvider
{
    public class ShoppingCartRepositoryProvider : IRepositoryProvider
    {
        private RepositoryFactory repositoryFactory;
        private IDictionary<Type, object> repositoriesMappedByType;

        #region Constructor

        public ShoppingCartRepositoryProvider(DbContext context, RepositoryFactory repositoryFactory)
        {
            if(context == null)
            {
                throw new ArgumentNullException("context");
            }
            if(repositoryFactory == null)
            {
                throw new ArgumentNullException("repositoryFactory");
            }

            this.Context = context;
            this.repositoryFactory = repositoryFactory;
            this.repositoriesMappedByType = new Dictionary<Type, object>();

            Debug.WriteLine("ShoppingCartRepositoryProvider created...");
        }

        #endregion

        #region IRepositoryProvider

        public DbContext Context { get; set; }
        public IRepository<T> GetRepository<T>() where T : class
        {
            var requestedType = typeof(T);
            
            object repository = null;
            if(this.repositoriesMappedByType.TryGetValue(requestedType, out repository))
            {
                return (IRepository<T>)(repository);
            }

            var repositoryFunc = this.repositoryFactory.GetRepositoryFunc<T>();
            if(repositoryFunc == null)
            {
                return null;
            }

            var stronglyTypedRepository = (IRepository<T>)(repositoryFunc(this.Context));
            this.repositoriesMappedByType.Add(requestedType, stronglyTypedRepository);

            return stronglyTypedRepository;
        }

        public void SetRepository<T>(IRepository<T> repository) where T : class
        {
            var requestedType = typeof(T);
            if(this.repositoriesMappedByType.ContainsKey(requestedType))
            {
                this.repositoriesMappedByType[requestedType] = repository;
            }
            else
            {
                this.repositoriesMappedByType.Add(requestedType, repository);
            }
        }

        #endregion
    }
}
