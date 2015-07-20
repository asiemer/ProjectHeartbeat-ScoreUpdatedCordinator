using NServiceBus;

namespace Coordinator
{
    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.EndpointName("ScoreUpdatedCoordinator.Coordinator");
            configuration.UseSerialization<XmlSerializer>();
            configuration.EnableInstallers();
            configuration.UsePersistence<NHibernatePersistence>();
            configuration.UseTransport<SqlServerTransport>();
            configuration.Conventions().DefiningEventsAs(t => t.Namespace != null && t.Namespace.StartsWith("Projects.Contracts.Events"));            
        }
    }
}

