using AngularProject.Model;
using AngularProject.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularProject.Controllers;

[Route("api/[controller]")]
[ApiController]

public class EventController : Controller
{
    public readonly AppDbContext _appDbContext;

    public EventController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetEvents()
    {
        return Ok(await _appDbContext.Events.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEventById(int id)
    {
        var events = await _appDbContext.Events.FirstOrDefaultAsync(x => x.eventId == id);

        if (events == null)
        {
            return NotFound();
        }

        return Ok(events);
    }
    [HttpPost]
    public async Task<IActionResult> AddEvent([FromBody] Event events)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _appDbContext.Events.Add(events);

        await _appDbContext.SaveChangesAsync();

        return Ok(events);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEvent([FromBody] Event events, int id)
    {
        var dbEvent = await _appDbContext.Events.FirstOrDefaultAsync(e => e.eventId == id);

        if (dbEvent == null)
        {
            return NotFound();
        }

        dbEvent.description = events.description;
        dbEvent.name = events.name;
        dbEvent.location = events.location;
        dbEvent.time = events.time;

        await _appDbContext.SaveChangesAsync();

        return Ok(dbEvent);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvent(int id)
    {
        var events = await _appDbContext.Events.FirstOrDefaultAsync(x => x.eventId == id);

        if (events == null)
        {
            return NotFound();
        }

        _appDbContext.Events.Remove(events);

        await _appDbContext.SaveChangesAsync();

        return NoContent();
    }
}
