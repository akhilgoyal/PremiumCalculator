using System.Configuration;
using System.Web.Mvc;
using Autofac;
using PremiumCalculator.Service;
using PremiumCalculator.Controllers;
//using PremiumCalculator.Domain;
using Autofac.Integration.Mvc;
using PremiumCalculator.Service.Interfaces;

namespace PremiumCalculator
{

    public static class RegisterModules
    {
        public static IContainer Register()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<Service.PremiumCalculator>().As<IPremiumCalculator>();
            containerBuilder.RegisterType<Service.AgeCalculator>().As<IAgeCalculator>();

            var instance = GetConfigInstance();

            containerBuilder.RegisterInstance<Config>(instance);
            containerBuilder.Register(c => new HomeController(c.Resolve<IPremiumCalculator>(), c.Resolve<IAgeCalculator>(), c.Resolve<Config>()));

            var container = containerBuilder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            return container;
        }

        private static Config GetConfigInstance()
        {
            var maleGenderFactor = ConfigurationManager.AppSettings["MaleGenderFactor"];
            var feMaleGenderFactor = ConfigurationManager.AppSettings["FeMaleGenderFactor"];
            var minAge = ConfigurationManager.AppSettings["MinAge"];
            var maxAge = ConfigurationManager.AppSettings["MaxAge"];
            var multiplier = ConfigurationManager.AppSettings["Multiplier"];

            var appConfig = new Config()
            {
                MaleGenderFactor = maleGenderFactor,
                FeMaleGenderFactor = feMaleGenderFactor,
                MinAge = minAge,
                MaxAge = maxAge,
                Multiplier = multiplier
            };

            return appConfig;
        }
    }
}
