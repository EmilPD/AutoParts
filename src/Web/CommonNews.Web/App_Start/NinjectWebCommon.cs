[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CommonNews.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(CommonNews.Web.App_Start.NinjectWebCommon), "Stop")]

namespace CommonNews.Web.App_Start
{
    using System;
    using System.Data.Entity;
    using System.Web;
    using AutoMapper;
    using Common.Contracts;
    using Data.Common;
    using Data.Common.Contracts;
    using Data.Models;
    using Identity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin.Security;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Extensions.Factory;
    using Ninject.Web.Common;
    using Services.Data;
    using Services.Data.Common.Contracts;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
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
            kernel.Bind<IAuthenticationManager>().ToMethod(
                c => HttpContext.Current.GetOwinContext().Authentication).InRequestScope();

            kernel.Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>();
            kernel.Bind<UserManager<ApplicationUser>>().ToSelf();

            kernel.Bind(x =>
            {
                x.FromThisAssembly()
                 .SelectAllClasses()
                 .BindDefaultInterface();
            });

            kernel.Bind(typeof(IDataService<>)).To(typeof(DataService<>)).InRequestScope();
            kernel.Bind(typeof(DbContext), typeof(MsSqlDbContext)).To<MsSqlDbContext>().InRequestScope();
            kernel.Bind(typeof(IEfRepository<>)).To(typeof(EfRepository<>)).InRequestScope();
            kernel.Bind<ISaveContext>().To<SaveContext>().InRequestScope();
            kernel.Bind<IMapper>().To<Mapper>().InSingletonScope();
            kernel.Bind<Mapper>().ToSelf();
            kernel.Bind<IPaginationFactory>().ToFactory().InSingletonScope();
            kernel.Bind<ApplicationUserManager>().ToSelf();
            kernel.Bind<ApplicationSignInManager>().ToSelf();
        }
    }
}
