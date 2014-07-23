namespace VideoStore.Sales
{
    using NServiceBus;
    using NServiceBus.Persistence;

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Publisher, UsingTransport<Msmq>, INeedInitialization
    {
        public void Init(Configure config)
        {
            config.UsePersistence<NHibernate>(c => c.For(Storage.Timeouts, Storage.Subscriptions, Storage.Sagas));
            config.RijndaelEncryptionService();
        }

        public void Customize(ConfigurationBuilder builder)
        {
            builder.Conventions(UnobtrusiveMessageConventions.Init);
        }
    }

}
