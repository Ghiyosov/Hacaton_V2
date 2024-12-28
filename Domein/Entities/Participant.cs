using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domein.Entities;

public class Participant
{
    [Key]
    public int ParticipantId { get; set; }
    [StringLength(75), Required]
    public string ParticipantName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Phone]
    public string PhoneNumber { get; set; }
    
    public int TeamId { get; set; }

    public string Role { get; set; }

    public string Skills { get; set; }

    public string ExperienceLevel { get; set; }

    public DateTime JoinedDate { get; set; }
    
    [ForeignKey("TeamId")]
    public Team Team { get; set; }
}