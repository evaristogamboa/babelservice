[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Babel.Interfaz.WebApi.AppStart.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Babel.Interfaz.WebApi.AppStart.NinjectWebCommon), "Stop")]

namespace Babel.Interfaz.WebApi.AppStart
{
    using System;
    using System.Web;

    using Babel.Nucleo.Aplicacion.Fachada;
    using Babel.Nucleo.Aplicacion.Servicios;
    using Babel.Nucleo.Dominio.Repositorios;
    using Babel.Repositorio.Xml.Impl.Implementacion;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Babel.Interfaz.WebApi.Controladores;

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
            kernel.Bind<IDiccionarioRepositorio>().To<DiccionarioRepositorioXmlImpl>();
            kernel.Bind<IAplicacionMantenimientoDiccionario>().To<AplicacionServicio>();
        }        
    }
}
