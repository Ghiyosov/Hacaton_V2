using Domein.DTOs.HacathonDTOs;
using Domein.DTOs.ParticipiantDTOs;
using Infrastructure.ApiResponses;

namespace Infrastructure.Interfaces;

public interface IParticipantService
{
    public Task<Response<List<ReadParticiantDTOs>>> ReadParticiants();
    public Task<Response<ReadParticiantDTOs>> ReadParticiant(int id);
    public Task<Response<string>> CreateParticiant(CraeteParticipiantDTOs participant);
    public Task<Response<string>> UpdateParticiant(int id, UpdateParticiantDTOs particiantDtOs);
    public Task<Response<string>> DeleteParticiant(int id);
}