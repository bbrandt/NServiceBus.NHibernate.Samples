namespace VideoStore.Operations
{
    using NServiceBus.Persistence;
    using NServiceBus;

	public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, UsingTransport<Msmq>, INeedInitialization
    {
	    public void Init(Configure config)
	    {
            config.UsePersistence<NHibernate>(c => c.For(Storage.Timeouts, Storage.Subscriptions, Storage.Sagas));
	    }

	    public void Customize(ConfigurationBuilder builder)
        {
            builder.Conventions(UnobtrusiveMessageConventions.Init);
	    }
    }
	

}
