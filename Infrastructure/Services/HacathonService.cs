using System.Net;
using Domein.DTOs.HacathonDTOs;
using Domein.Entities;
using Infrastructure.ApiResponses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class HacathonService(DataCintext _data) : IHacatonService
{
    public async Task<Response<List<ReadHacathonDTO>>> ReadHacatons()
    {
        var x = await _data.Hackathons.ToListAsync();
        var response = x.Select(x => new ReadHacathonDTO()
        {
            HacathonId = x.HackathonId,
            HacathonName = x.HackathonName,
            Date = x.Date,
            Theme = x.Theme,
            Location = x.Location,
            MaxTeams = x.MaxTeams,
            Description = x.Description,
            Teams = x.Teams
        });
        return new Response<List<ReadHacathonDTO>>(response.ToList());
    }

    public async Task<Response<ReadHacathonDTO>> ReadHacaton(int id)
    {
       var x = await _data.Hackathons.FirstOrDefaultAsync(x => x.HackathonId == id);
       
       if (x == null)
           return new Response<ReadHacathonDTO>(HttpStatusCode.NotFound, "Hacaton not found");

       
       var res = new ReadHacathonDTO()
       {
           HacathonId = x.HackathonId,
           HacathonName = x.HackathonName,
           Date = x.Date,
           Theme = x.Theme,
           Location = x.Location,
           MaxTeams = x.MaxTeams,
           Description = x.Description,
           Teams = x.Teams
       };
       
       return new Response<ReadHacathonDTO>(res);
    }

    public async Task<Response<string>> CreateHacaton(CreateHacathonDTO hacaton)
    {
        var res = new Hackathon()
        {
            HackathonName = hacaton.HacathonName,
            Date = hacaton.Date,
            Theme = hacaton.Theme,
            Location = hacaton.Location,
            MaxTeams = hacaton.MaxTeams,
            Description = hacaton.Description,
        };
        
        await _data.Hackathons.AddAsync(res);
        
        var x = await _data.SaveChangesAsync();
        return x==0 
            ? new Response<string>(HttpStatusCode.Created, "Hacaton created")
            : new Response<string>(HttpStatusCode.OK, "Hacaton created");
    }

    public async Task<Response<string>> UpdateHacaton(int id, UpdateHacathonDTO hacaton)
    {
        var x = await _data.Hackathons.FirstOrDefaultAsync(x => x.HackathonId == id);
        if (x==null)
            return new Response<string>(HttpStatusCode.NotFound, "Hacaton not found");
        
        x.HackathonName = hacaton.HacathonName;
        x.Date = hacaton.Date;
        x.Theme = hacaton.Theme;
        x.Location = hacaton.Location;
        x.MaxTeams = hacaton.MaxTeams;
        x.Description = hacaton.Description;
        
        var result = await _data.SaveChangesAsync();
        return result == 0
            ? new Response<string>(HttpStatusCode.NoContent, "Hacaton updated")
            : new Response<string>(HttpStatusCode.OK, "Hacaton updated");
    }

    public async Task<Response<string>> DeleteHacaton(int id)
    {
        var x = await _data.Hackathons.FirstOrDefaultAsync(x => x.HackathonId == id);
        if (x==null)
            return new Response<string>(HttpStatusCode.NotFound, "Hacaton not found");
        _data.Hackathons.Remove(x);
        var result = await _data.SaveChangesAsync();
        return result == 0 
            ? new Response<string>(HttpStatusCode.NoContent, "Hacaton deleted")
            : new Response<string>(HttpStatusCode.OK, "Hacaton deleted");
    }
}