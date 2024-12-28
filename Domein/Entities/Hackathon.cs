using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Domein.Entities;

public class Hackathon
{
    [Key]
    public int HackathonId { get; set; }
    [StringLength(150), Required]
    public string HackathonName { get; set; }
    
    public DateTime Date { get; set; }
    
    public string Theme { get; set; }
    
    public string Location { get; set; }
    
    public int MaxTeams { get; set; }
    
    public string Description { get; set; }

    public List<Team> Teams { get; set; }
}