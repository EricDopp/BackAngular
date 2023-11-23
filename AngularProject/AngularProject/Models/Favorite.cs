using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularProject.Models;

public class Favorite
{
    [Key]
    public int favoriteId {  get; set; }
    public int userId {  get; set; }
    [ForeignKey("eventId")]
    public int eventId { get; set; }
}
