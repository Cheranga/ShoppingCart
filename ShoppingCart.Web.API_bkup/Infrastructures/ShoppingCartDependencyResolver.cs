﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Web.Common;
using ShoppingCart.DAL;
using ShoppingCart.DAL.Factories;
using ShoppingCart.DAL.RepositoryProvider;
using ShoppingCart.DAL.UoW;
using ShoppingCart.Infrastructure.RepositoryProvider;
using ShoppingCart.Infrastructure.UoW;

namespace ShoppingCart.Web.API.Infrastructures
{
    public class ShoppingCartDependencyResolver : IDependencyResolver, System.Web.Mvc.IDependencyResolver
    {
        private readonly IKernel kernel;

        public ShoppingCartDependencyResolver(IKernel kernel)
        {
            if(kernel == null)
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

        public object GetService(Type serviceType)
        {
            return this.kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.kernel.GetAll(serviceType);
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}