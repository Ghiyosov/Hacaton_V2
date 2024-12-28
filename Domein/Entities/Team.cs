using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domein.Entities;

public class Team
{
    [Key]
    public int TeamId { get; set; }
    [StringLength(150), Required]
    public string TeamName { get; set; }
    
    public int HackathonId { get; set; }

    public DateTime CreatedDate { get; set; }

    public string Leader { get; set; }

    public int TotalMembers { get; set; }

    public int Score { get; set; }

    public string Status { get; set; }
    
    [ForeignKey("HackathonId")]
    public Hackathon Hackathon { get; set; }

    public List<Participant> Participants { get; set; }
    
}