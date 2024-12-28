using Domein.Entities;

namespace Domein.DTOs.TeamDTOs;

public class ReadTeamDTOs
{
    public int TeamId { get; set; }
    public string TeamName { get; set; }
    
    public int HackathonId { get; set; }

    public DateTime CreatedDate { get; set; }

    public string Leader { get; set; }

    public int TotalMembers { get; set; }

    public int Score { get; set; }

    public string Status { get; set; }

    public List<Participant> Participants { get; set; }
}