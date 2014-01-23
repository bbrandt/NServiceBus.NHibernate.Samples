namespace VideoStore.ContentManagement
{
    using NServiceBus;

    class InititalizeSubscriptionStorage : INeedInitialization
    {
        public void Init()
        {
            NServiceBus.Configure.Instance
                .UseNHibernateSubscriptionPersister() // subscription storage using NHibernate
                .UseNHibernateTimeoutPersister() // Timeout Persistance using NHibernate
                .UseNHibernateSagaPersister(); // Saga Persistance using NHibernate
        }
    }
}
