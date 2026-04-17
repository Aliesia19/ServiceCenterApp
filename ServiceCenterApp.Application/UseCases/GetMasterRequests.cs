using ServiceCenterApp.Application.Interfaces;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Interfaces;

public class GetMasterRequests
{
    private readonly IRequestRepository _repo;
    private readonly IMapper<RepairRequest, RepairRequestDto> _mapper;

    public GetMasterRequests(
        IRequestRepository repo,
        IMapper<RepairRequest, RepairRequestDto> mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<List<RepairRequestDto>> Execute(Guid masterId)
    {
       
        var data = await _repo.GetByMasterIdAsync(masterId);

        return data.Select(_mapper.ToDto).ToList();
    }
}