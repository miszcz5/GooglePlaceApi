using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using GoogleApi;
using MainApplication;
using MainApplication.Repository;
using Microsoft.Practices.Unity;
using Storage;
using WebApplication.Resolver;

namespace WebApplication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IDataProvider, DataProvider>(new HierarchicalLifetimeManager());
            container.RegisterType<IStorageProvider, StorageService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IRepository, Repository>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
