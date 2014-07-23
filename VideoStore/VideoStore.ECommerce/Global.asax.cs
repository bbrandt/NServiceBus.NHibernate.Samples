namespace VideoStore.ECommerce
{
    using NServiceBus.Persistence;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using NServiceBus;

    public class MvcApplication : HttpApplication
    {
        public static IBus Bus;

        protected void Application_Start()
        {
            var configure = Configure.With(builder => builder.Conventions(UnobtrusiveMessageConventions.Init))
                .PurgeOnStartup(true)
                .RijndaelEncryptionService()
                .UsePersistence<NHibernate>(c => c.For(Storage.Timeouts, Storage.Sagas))
                .EnableInstallers();
            var startableBus = configure.CreateBus();
            Bus = startableBus.Start();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

    }
}