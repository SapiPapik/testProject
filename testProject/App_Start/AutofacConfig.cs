using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using TestProject.BLL.Services;
using TestProject.DAL;
using TestProject.DAL.Contract;
using TestProject.DAL.Repository;

namespace testProject {
    public class AutofacConfing {
        public static void RegisterComponents() {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(typeof(WebApiApplication).Assembly);
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            //// OPTIONAL: Enable action method parameter injection (RARE).
            //builder.InjectActionInvoker();

            builder.RegisterType<TestProjectDbContext>().As<DbContext>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EntityRepository<>)).As(typeof(IBaseRepository<>));
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(GroupService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();


            // Set the dependency resolver to be Autofac.
            var container = builder.Build();

            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}