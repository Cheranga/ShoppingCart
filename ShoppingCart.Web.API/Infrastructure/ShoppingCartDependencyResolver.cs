using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.WebApi;
using ShoppingCart.Business.Models;
using ShoppingCart.DAL;
using ShoppingCart.DAL.Factories;
using ShoppingCart.DAL.RepositoryProvider;
using ShoppingCart.DAL.UoW;
using ShoppingCart.DTO;
using ShoppingCart.DTO.DTOs;
using ShoppingCart.DTO.Extensions.Transformations;
using ShoppingCart.Infrastructure.RepositoryProvider;
using ShoppingCart.Infrastructure.UoW;

namespace ShoppingCart.Web.API.Infrastructure
{
    public class ShoppingCartDependencyResolver : NinjectDependencyScope, System.Web.Mvc.IDependencyResolver, System.Web.Http.Dependencies.IDependencyResolver
    {
        private readonly IKernel kernel;

        public ShoppingCartDependencyResolver(IKernel kernel):base(kernel)
        {
            if (kernel == null)
            {
                throw new ArgumentNullException("kernel");
            }

            this.kernel = kernel;

            RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            this.kernel.Bind<IDictionary<Type, Func<DbContext, object>>>().To<Dictionary<Type, Func<DbContext, object>>>();
            //
            // Entity Transformers (Singleton scope)
            //
            this.kernel.Bind<IEntityTransform<SalesOrderDTO, SalesOrder>>().To<SalesOrderTransformations>().InSingletonScope();

            //
            // Create the factory in singleton scope
            //
            this.kernel.Bind<RepositoryFactory>().To<RepositoryFactory>().InSingletonScope();
            //
            // Create the dbcontext and the uow in the current request scope
            //
            this.kernel.Bind<IRepositoryProvider>().To<ShoppingCartRepositoryProvider>().InRequestScope();
            this.kernel.Bind<DbContext>().To<ShoppingCartDbContext>().InRequestScope();
            this.kernel.Bind<IUoW>().To<ShoppingCartUoW>().InRequestScope();
        }

        //public object GetService(Type serviceType)
        //{
        //    return this.kernel.TryGet(serviceType);
        //}

        //public IEnumerable<object> GetServices(Type serviceType)
        //{
        //    return this.kernel.GetAll(serviceType);
        //}

        public IDependencyScope BeginScope()
        {
            return this;
        }
    }
}