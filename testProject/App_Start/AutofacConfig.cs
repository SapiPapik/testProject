using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using TestPrject.DAL.Contract;
using TestProject.BLL.Services;
using TestProject.DAL;
using TestProject.DAL.Contracts;
using TestProject.DAL.Repository;
using Autofac.Integration.WebApi;
using testProject;
using System.Web.Http;

namespace TestProject.Web.App_Start
{
    public class AutofacConfing
    {
        public static void RegisterComponents()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);

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

            builder.RegisterType<GroupsContext>().As<DbContext>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GlobalRepository<>)).As(typeof(IGlobalRepository<>));
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