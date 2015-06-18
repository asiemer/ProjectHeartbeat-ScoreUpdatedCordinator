using NServiceBus;
using Projects.Contracts.Events;


public class ProjectScoreHandler : IHandleMessages<ProjectScoreChanged>
{
    private readonly IBus _bus;

    public ProjectScoreHandler(IBus bus)
    {
        _bus = bus;
    }

    public void Handle(ProjectScoreChanged message)
    {
        _bus.Send("Dashboard.Dashboard", new UpdateProjectScore { Id = message.Id, Red = message.Red, Green = message.Green, Yellow = message.Yellow });
    }
}