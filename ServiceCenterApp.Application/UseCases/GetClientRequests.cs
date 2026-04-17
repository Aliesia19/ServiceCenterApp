using ServiceCenterApp.Application.Interfaces;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Interfaces;

public class GetClientRequests
{
    private readonly IRequestRepository _repo;
    private readonly IMapper<RepairRequest, RepairRequestDto> _mapper;

    public GetClientRequests(
        IRequestRepository repo,
        IMapper<RepairRequest, RepairRequestDto> mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<List<RepairRequestDto>> Execute(Guid clientId)
    {
        var data = await _repo.GetByClientIdAsync(clientId);

        return data.Select(_mapper.ToDto).ToList();
    }
}