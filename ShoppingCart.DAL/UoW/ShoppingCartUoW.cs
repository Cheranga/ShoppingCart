using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ShoppingCart.Infrastructure.Repositories;
using ShoppingCart.Infrastructure.RepositoryProvider;
using ShoppingCart.Infrastructure.UoW;

namespace ShoppingCart.DAL.UoW
{
    public class ShoppingCartUoW : IUoW
    {
        private readonly IRepositoryProvider repositoryProvider;
        private readonly DbContext context;


        public ShoppingCartUoW(DbContext context, IRepositoryProvider repositoryProvider)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (repositoryProvider == null)
            {
                throw new ArgumentNullException("repositoryProvider");
            }

            this.context = context;
            this.repositoryProvider = repositoryProvider;

            Debug.WriteLine("ShoppingCartUoW created...");
        }

        #region IUoW Implementation

        public bool Commit()
        {
            var wasCommitSuccessful = true;

            using (var transactionScope = this.context.Database.BeginTransaction())
            {
                try
                {
                    context.SaveChanges();
                    transactionScope.Commit();
                }
                catch (Exception exception)
                {
                    // TODO: Log properly
                    Debug.WriteLine(exception.StackTrace);

                    wasCommitSuccessful = false;
                    transactionScope.Rollback();
                }
            }

            return wasCommitSuccessful;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            var repository = this.repositoryProvider.GetRepository<T>();
            return repository;
        }

        #endregion
    }
}
