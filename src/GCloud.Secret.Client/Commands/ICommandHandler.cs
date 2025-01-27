namespace GCloud.Secret.Client.Commands;

public interface ICommandHandler
{
    string CommandName { get; }

    string Description { get; }

    Task<ContinueStatusEnum> Handle(CommandState state, CancellationToken cancellationToken);
}