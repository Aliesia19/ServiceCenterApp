using ServiceCenterApp.Domain.Enums;

namespace ServiceCenterApp.Application.Queries
{
    public class GetAllRequestsQuery
    {
        public RequestStatus? Status { get; set; }
    }
}