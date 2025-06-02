namespace Hex.Arc.Core.Ports;

//(Secondary Port)
public interface INotificationService
{
    Task SendTransferNotification(string message, string recipient);
}
