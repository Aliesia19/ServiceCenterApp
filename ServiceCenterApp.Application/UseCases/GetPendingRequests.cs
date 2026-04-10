using ServiceCenterApp.Application.Interfaces;
using ServiceCenterApp.Domain.Enums;
using ServiceCenterApp.Domain.Interfaces;

public class GetPendingRequests
{
    private readonly IRequestRepository _repo;
    private readonly IMapper<RepairRequest, RepairRequestDto> _mapper;

    public GetPendingRequests(IRequestRepository repo, IMapper<RepairRequest, RepairRequestDto> mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<List<RepairRequestDto>> Execute()
    {
        var data = await _repo.GetByStatusAsync(RequestStatus.New);
        return data.Select(_mapper.ToDto).ToList();
    }
}