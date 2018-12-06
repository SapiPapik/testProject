using System.Data.Entity.Migrations;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using testProject;
using testProject.DataMappingProfileWeb;
using TestProject.BLL.DataMappingProfile;
using TestProject.DAL.Migrations;

namespace testProject {
    public class WebApiApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            //UpdateDatabase();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutofacConfing.RegisterComponents();
            Mapper.Initialize(cfg => {
                cfg.AddProfile<DataMappingsProfile>();
                cfg.AddProfile<DataMappingsProfileWeb>();
            });
        }

        private void UpdateDatabase() {
            var migrationConfig = new Configuration();
            var migrator = new DbMigrator(migrationConfig);
            migrator.Update();
        }
    }
}
