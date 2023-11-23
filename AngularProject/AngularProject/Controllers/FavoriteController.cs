using AngularProject.Model;
using AngularProject.Models;
using AngularProject.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AngularProject.Controllers;

[Route("api/[controller]")]
[ApiController]

public class FavoriteController : Controller
{
    private readonly AppDbContext _appDbContext;
    public FavoriteController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    [HttpGet]
    public async Task<IActionResult> GetFavorites()
    {
        var favorites = await _appDbContext.Favorites
            .Join(
                _appDbContext.Events,
                fav => fav.eventId,
                ev => ev.eventId,
                (fav, ev) => new
                {
                    FavoriteId = fav.favoriteId,
                    UserId = fav.userId,
                    EventId = fav.eventId,
                    Event = ev
                }
            )
            .ToListAsync();

        return Ok(favorites);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetFavoriteById(int id)
    {
        var favorite = await _appDbContext.Favorites
            .Join(
                _appDbContext.Events,
                fav => fav.eventId,
                ev => ev.eventId,
                (fav, ev) => new
                {
                    FavoriteId = fav.favoriteId,
                    UserId = fav.userId,
                    EventId = fav.eventId,
                    Event = ev
                }
            )
            .FirstOrDefaultAsync(x => x.FavoriteId == id);

        if (favorite == null)
        {
            return NotFound();
        }

        return Ok(favorite);
    }
    [HttpPost]
    public async Task<IActionResult> AddFavorite(int eventId, int userId)
    {
        var existingEvent = await _appDbContext.Events.FirstOrDefaultAsync(e => e.eventId == eventId);
        if (existingEvent == null)
        {
            return BadRequest("The specified event does not exist.");
        }

        var existingFavorite = await _appDbContext.Favorites.FirstOrDefaultAsync(f => f.eventId == eventId && f.userId == userId);
        if (existingFavorite != null)
        {
            return BadRequest("The event is already in the user's favorites.");
        }

        var newFavorite = new Favorite
        {
            userId = userId,
            eventId = eventId,
        };

        _appDbContext.Favorites.Add(newFavorite);
        await _appDbContext.SaveChangesAsync();

        return Ok(newFavorite);
    }
    [HttpDelete("{favoriteId}/{userId}")]
    public async Task<IActionResult> DeleteFavorite(int favoriteId, int userId)
    {
        var favoriteEvent = await _appDbContext.Favorites.FirstOrDefaultAsync(x => x.favoriteId == favoriteId && x.userId == userId);

        if (favoriteEvent == null) 
        {
            return NotFound();
        }

        _appDbContext.Favorites.Remove(favoriteEvent);

        await _appDbContext.SaveChangesAsync();

        return NoContent();
    }
}
