using System.Web.Http;
using System.Web.Mvc;
using ShoppingCart.Web.API.Infrastructure;

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
            /*
             * Since we need have the same dependency resolver for both web MVC and web API
             * http://stackoverflow.com/questions/21158274/using-ninject-dependecyresolver-for-both-mvc-and-webapi
             * http://blog.developers.ba/simple-way-share-container-mvc-web-api/
             * http://wildermuth.com/2012/02/26/WebAPI_and_Ninject
            */

            var appDependencyResolver = new ShoppingCartDependencyResolver(kernel);
            DependencyResolver.SetResolver(appDependencyResolver);
            GlobalConfiguration.Configuration.DependencyResolver = appDependencyResolver;
        }        
    }
}
