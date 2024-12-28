using Domein.DTOs.TeamDTOs;
using Domein.Entities;
using Infrastructure.ApiResponses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class TeamService(DataCintext _data) : ITeamService
{
    public async Task<Response<List<ReadTeamDTOs>>> ReadTeams()
    {
        var res = await _data.Teams.ToListAsync();

        var teams = res.Select(x => new ReadTeamDTOs()
        {
            TeamId = x.TeamId,
            TeamName = x.TeamName,
            HackathonId = x.HackathonId,
            CreatedDate = x.CreatedDate,
            Leader = x.Leader,
            TotalMembers = x.TotalMembers,
            Score = x.Score,
            Status = x.Status,
            Participants = x.Participants
        });
        return new Response<List<ReadTeamDTOs>>(teams.ToList());
    }

    public async Task<Response<ReadTeamDTOs>> ReadTeam(int id)
    {
        var x = await _data.Teams.FirstOrDefaultAsync(x => x.TeamId == id);
        var team = new ReadTeamDTOs()
        {
            TeamId = x.TeamId,
            TeamName = x.TeamName,
            HackathonId = x.HackathonId,
            CreatedDate = x.CreatedDate,
            Leader = x.Leader,
            TotalMembers = x.TotalMembers,
            Score = x.Score,
            Status = x.Status,
            Participants = x.Participants
        };
        return new Response<ReadTeamDTOs>(team);
    }

    public async Task<Response<string>> CreateTeam(CreateTeamDTOs team)
    {
        var te = new Team()
        {
            TeamName = team.TeamName,
            HackathonId = team.HackathonId,
            Leader = team.Leader,
            CreatedDate = team.CreatedDate,
            TotalMembers = team.TotalMembers,
            Score = team.Score,
            Status = team.Status,
        };
        await _data.Teams.AddAsync(te);
        var res = await _data.SaveChangesAsync();
        return res == 0 
            ? new Response<string>($"Team {te.TeamName} was created")
            : new Response<string>($"Team {te.TeamName} has been created");
    }

    public async Task<Response<string>> UpdateTeam(int id, UpdateTeamDTOs team)
    {
        var res = await _data.Teams.FirstOrDefaultAsync(x => x.TeamId == id);
        if(res == null)
            return new Response<string>($"Team ID:{id} could not be found");
        
        res.TeamName = team.TeamName;
        res.HackathonId = team.HackathonId;
        res.Leader = team.Leader;
        res.CreatedDate = team.CreatedDate;
        res.TotalMembers = team.TotalMembers;
        res.Score = team.Score;
        res.Status = team.Status;
        
        var x = await _data.SaveChangesAsync();
        return x == 0 
            ? new Response<string>($"Team {res.TeamName} has been updated")
            : new Response<string>($"Team {res.TeamName} hasn't been updated");
    }

    public async Task<Response<string>> DeleteTeam(int id)
    {
        var res = await _data.Teams.FirstOrDefaultAsync(x => x.TeamId == id);
        if(res == null)
            return new Response<string>($"Team ID:{id} could not be found");
        
        _data.Teams.Remove(res);
        var x = await _data.SaveChangesAsync();
        return x == 0 
            ? new Response<string>($"Team {res.TeamName} has been deleted")
            : new Response<string>($"Team {res.TeamName} hasn't been deleted");

    }
}