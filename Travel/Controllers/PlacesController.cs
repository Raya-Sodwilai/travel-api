using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel.Models;

namespace Travel.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PlacesController : ControllerBase
  {
    private readonly TravelContext _db;

    public PlacesController(TravelContext db)
    {
      _db = db;
    }

    // GET: api/Places
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Place>>> Get(string reviews, string country)
    {
      var query = _db.Places.AsQueryable();

      if (reviews != null)
      {
        query = query.Where(entry => entry.Reviews == reviews);
      }
      if (country != null)
      {
        query = query.Where(entry => entry.Country == country);
      }

      return await query.ToListAsync();
    }

    // GET: api/Places/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Place>> GetPlace(int id)
    {
        var place = await _db.Places.FindAsync(id);

        if (place == null)
        {
          return NotFound();
        }

        return place;
    }

    // PUT: api/Places/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Place place)
    {
      if (id != place.PlaceId)
      {
        return BadRequest();
      }

      _db.Entry(place).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!PlaceExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/Places
    [HttpPost]
    public async Task<ActionResult<Place>> Post(Place place)
    {
      _db.Places.Add(place);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetPlace), new { id = place.PlaceId }, place);
    }

    // DELETE: api/Places/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlace(int id)
    {
      var place = await _db.Places.FindAsync(id);
      if (place == null)
      {
        return NotFound();
      }

      _db.Places.Remove(place);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool PlaceExists(int id)
    {
      return _db.Places.Any(e => e.PlaceId == id);
    }
  }
}