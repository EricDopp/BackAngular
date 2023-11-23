using System.ComponentModel.DataAnnotations;

namespace AngularProject.Model;

public class Event
{
    [Key]
    public int eventId { get ; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string location { get; set; }
    public DateTime time { get; set; }
}
