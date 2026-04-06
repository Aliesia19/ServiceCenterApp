// ServiceCenterApp.Domain/Enums/RequestStatus.cs
namespace ServiceCenterApp.Domain.Enums
{
    public enum RequestStatus
    {
        New,
        InProgress,
        Diagnostic,
        Repairing,
        Completed,
        Canceled
    }
}