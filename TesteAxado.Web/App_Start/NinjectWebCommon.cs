using TesteAxado.Application.Interfaces;
using TesteAxado.Domain.Interfaces.Repositories;
using TesteAxado.Domain.Interfaces.Services;
using TesteAxado.Domain.Services;
using TesteAxado.Infra.Data.Repositories;


[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TesteAxado.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(TesteAxado.Web.App_Start.NinjectWebCommon), "Stop")]

namespace TesteAxado.Web.App_Start
{
    using Application.Services;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using System;
    using System.Web;
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

        //TODO - SimpleInjector?
        //TODO - Remover referencia Data
        // criar um modulo

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IApplicationServiceBase<>)).To(typeof(ApplicationServiceBase<>));
            kernel.Bind<IUserApplicationService>().To<UserApplicationService>();
            kernel.Bind<ICarrierApplicationService>().To<CarrierApplicationService>();
            kernel.Bind<IRatingApplicationService>().To<RatingApplicationService>();

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<ICarrierService>().To<CarrierService>();
            kernel.Bind<IRatingService>().To<RatingService>();

            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<ICarrierRepository>().To<CarrierRepository>();
            kernel.Bind<IRatingRepository>().To<RatingRepository>();
        }
    }
}
