namespace Domein.DTOs.ParticipiantDTOs;

public class UpdateParticiantDTOs
{
    
    public string ParticipantName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    
    public int TeamId { get; set; }

    public string Role { get; set; }

    public string Skills { get; set; }

    public string ExperienceLevel { get; set; }

    public DateTime JoinedDate { get; set; }
    
}