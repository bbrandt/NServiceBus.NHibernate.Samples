using NServiceBus.Persistence;

namespace VideoStore.CustomerRelations
{
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Publisher, UsingTransport<Msmq>, INeedInitialization
    {
        public void Customize(ConfigurationBuilder builder)
        {
            builder.Conventions(UnobtrusiveMessageConventions.Init);
        }
        public void Init(Configure config)
        {
            config.UsePersistence<NHibernate>(c => c.For(Storage.Timeouts, Storage.Sagas));
        }
    }
}