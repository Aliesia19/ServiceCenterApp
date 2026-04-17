using ServiceCenterApp.Domain.Enums;

namespace ServiceCenterApp.Application.Queries
{
    public class GetPendingRequestsQuery
    {
        public RequestStatus Status { get; set; } = RequestStatus.New;
    }
}