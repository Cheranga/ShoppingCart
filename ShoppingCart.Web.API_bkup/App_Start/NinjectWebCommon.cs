using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;
using ShoppingCart.DAL;
using ShoppingCart.DAL.Factories;
using ShoppingCart.DAL.RepositoryProvider;
using ShoppingCart.DAL.UoW;
using ShoppingCart.Infrastructure.RepositoryProvider;
using ShoppingCart.Infrastructure.UoW;
using ShoppingCart.Web.API.Infrastructures;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ShoppingCart.Web.API.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ShoppingCart.Web.API.App_Start.NinjectWebCommon), "Stop")]

namespace ShoppingCart.Web.API.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //DependencyResolver.SetResolver(new ShoppingCartDependencyResolver(kernel));
           

            kernel.Bind<IDictionary<Type, Func<DbContext, object>>>().To<Dictionary<Type, Func<DbContext, object>>>();

            //
            // Create the factory in singleton scope
            //
            kernel.Bind<RepositoryFactory>().To<RepositoryFactory>().InSingletonScope();
            //
            // Create the dbcontext and the uow in the current request scope
            //
            kernel.Bind<IRepositoryProvider>().To<ShoppingCartRepositoryProvider>().InRequestScope();
            kernel.Bind<DbContext>().To<ShoppingCartDbContext>().InRequestScope();
            kernel.Bind<IUoW>().To<ShoppingCartUoW>().InRequestScope();
        }        
    }
}
