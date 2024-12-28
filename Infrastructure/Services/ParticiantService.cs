using Domein.DTOs.HacathonDTOs;
using Domein.DTOs.ParticipiantDTOs;
using Domein.Entities;
using Infrastructure.ApiResponses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ParticiantService(DataCintext _data) : IParticipantService
{
    public async Task<Response<List<ReadParticiantDTOs>>> ReadParticiants()
    {
        var res = await _data.Participants.ToListAsync();

        var particiants = res.Select(x => new ReadParticiantDTOs()
        {
            ParticipantId = x.ParticipantId,
            ParticipantName = x.ParticipantName,
            PhoneNumber = x.PhoneNumber,
            Email = x.Email,
            TeamId = x.TeamId,
            Role = x.Role,
            Skills = x.Skills,
            ExperienceLevel = x.ExperienceLevel,
            JoinedDate = x.JoinedDate
        });
        
        return new Response<List<ReadParticiantDTOs>>(particiants.ToList());
    }

    public async Task<Response<ReadParticiantDTOs>> ReadParticiant(int id)
    {
        var x = await _data.Participants.FirstOrDefaultAsync(x => x.ParticipantId == id);
        var particiant = new ReadParticiantDTOs()
        {
            ParticipantId = x.ParticipantId,
            ParticipantName = x.ParticipantName,
            PhoneNumber = x.PhoneNumber,
            Email = x.Email,
            TeamId = x.TeamId,
            Role = x.Role,
            Skills = x.Skills,
            ExperienceLevel = x.ExperienceLevel,
            JoinedDate = x.JoinedDate
        };
        return new Response<ReadParticiantDTOs>(particiant);
    }

    public async Task<Response<string>> CreateParticiant(CraeteParticipiantDTOs createHacathon)
    {
        var hacathon = new Participant()
        {
            ParticipantName = createHacathon.ParticipantName,
            PhoneNumber = createHacathon.PhoneNumber,
            Email = createHacathon.Email,
            TeamId = createHacathon.TeamId,
            Role = createHacathon.Role,
            Skills = createHacathon.Skills,
            ExperienceLevel = createHacathon.ExperienceLevel,
            JoinedDate = createHacathon.JoinedDate
        };
        await _data.Participants.AddAsync(hacathon);
        var res = await _data.SaveChangesAsync();
        return res == 0 
            ? new Response<string>($"Participant {hacathon.ParticipantName} was created")
            : new Response<string>($"Participant {hacathon.ParticipantName} wasn't created");
    }

    public async Task<Response<string>> UpdateParticiant(int id, CraeteParticipiantDTOs updateHacathon)
    {
        var hacathon = await _data.Participants.FirstOrDefaultAsync(x => x.ParticipantId == id);
    }

    public Task<Response<string>> DeleteParticiant(int id)
    {
        throw new NotImplementedException();
    }
}