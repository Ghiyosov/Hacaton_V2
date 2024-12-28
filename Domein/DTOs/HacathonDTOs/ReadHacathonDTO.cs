using Domein.Entities;

namespace Domein.DTOs.HacathonDTOs;

public class ReadHacathonDTO
{
    public int HacathonId { get; set; }
    public string HacathonName { get; set; }
    public DateTime Date { get; set; }
    public string Theme { get; set; }
    public string Location { get; set; }
    public int MaxTeams { get; set; }
    public string Description { get; set; }
    public List<Team> Teams { get; set; }

}