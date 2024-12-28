using Domein.DTOs.HacathonDTOs;
using Infrastructure.ApiResponses;

namespace Infrastructure.Interfaces;

public interface IHacatonService
{
    public Task<Response<List<ReadHacathonDTO>>> ReadHacatons();
    public Task<Response<ReadHacathonDTO>> ReadHacaton(int id);
    public Task<Response<string>> CreateHacaton(CreateHacathonDTO hacaton);
    public Task<Response<string>> UpdateHacaton(int id, UpdateHacathonDTO hacaton);
    public Task<Response<string>> DeleteHacaton(int id);
}