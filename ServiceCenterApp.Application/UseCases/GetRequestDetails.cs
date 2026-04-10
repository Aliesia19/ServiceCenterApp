using ServiceCenterApp.Application.Interfaces;
using ServiceCenterApp.Domain.Interfaces;

public class GetRequestDetails
{
    private readonly IRequestRepository _repo;
    private readonly IMapper<RepairRequest, RequestDetailsDto> _mapper;

    public GetRequestDetails(IRequestRepository repo, IMapper<RepairRequest, RequestDetailsDto> mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<RequestDetailsDto?> Execute(Guid id)
    {
        var request = await _repo.GetByIdAsync(id);
        return request == null ? null : _mapper.ToDto(request);
    }
}