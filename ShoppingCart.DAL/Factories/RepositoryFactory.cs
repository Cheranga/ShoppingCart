using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Business.Models;
using ShoppingCart.DAL.Repositories;
using ShoppingCart.Infrastructure.Repositories;

namespace ShoppingCart.DAL.Factories
{
    public class RepositoryFactory
    {
        private readonly IDictionary<Type, Func<DbContext,object>> repositoryFuncsMappedByType;

        public RepositoryFactory(IDictionary<Type, Func<DbContext, object>> repositoryFuncsMappedByType)
        {
            if (repositoryFuncsMappedByType == null || repositoryFuncsMappedByType.Keys.Count == 0)
            {
                this.repositoryFuncsMappedByType = GetRegisteredRepositoryFuncDictionary();
            }
            else
            {
                this.repositoryFuncsMappedByType = repositoryFuncsMappedByType;
            }

            Debug.WriteLine("RepositoryFactory created...");
        }

        private IDictionary<Type, Func<DbContext, object>> GetRegisteredRepositoryFuncDictionary()
        {
            var registeredRepositoryDictionary = new Dictionary<Type, Func<DbContext,object>>
                                                 {
                                                     {typeof(SalesOrder), context=> new BaseRepository<SalesOrder>(context)}
                                                 };

            return registeredRepositoryDictionary;
        }

        public Func<DbContext, object> GetRepositoryFunc<T>() where T:class
        {
            Func<DbContext, object> repositoryFunc = null;
            this.repositoryFuncsMappedByType.TryGetValue(typeof(T), out repositoryFunc);

            return repositoryFunc;
        }
    }
}
