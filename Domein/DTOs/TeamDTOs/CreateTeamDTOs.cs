using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domein.DTOs.TeamDTOs;

public class CreateTeamDTOs
{
    public string TeamName { get; set; }
    
    public int HackathonId { get; set; }

    public DateTime CreatedDate { get; set; }

    public string Leader { get; set; }

    public int TotalMembers { get; set; }

    public int Score { get; set; }

    public string Status { get; set; }
    
}