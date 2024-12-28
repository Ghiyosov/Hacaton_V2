using Domein.DTOs.TeamDTOs;
using Infrastructure.ApiResponses;

namespace Infrastructure.Interfaces;

public interface ITeamService
{
    public Task<Response<List<ReadTeamDTOs>>> ReadTeams();
    public Task<Response<ReadTeamDTOs>> ReadTeam(int id);
    public Task<Response<string>> CreateTeam(CreateTeamDTOs team);
    public Task<Response<string>> UpdateTeam(int id, UpdateTeamDTOs team);
    public Task<Response<string>> DeleteTeam(int id);
}