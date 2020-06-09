using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using TravelApi.Models;
using Microsoft.EntityFrameworkCore;
namespace TravelApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PlacesController : ControllerBase
  {
    private TravelApiContext _db;

    public PlacesController(TravelApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Place>> Get(string city, string country, double rating)
    {
      var query = _db.Places.AsQueryable();

      if (city != null)
      {
        query = query.Where(entry => entry.City == city);
      }

      if (country != null)
      {
        query = query.Where(entry => entry.Country == country);
      }

      if (rating != null)
      {
        query = query.Where(entry => entry.Rating == rating);
      }
      return query.ToList();
    }

    [HttpPost]
    public void Post([FromBody] Place place)
    {
      _db.Places.Add(place);
      _db.SaveChanges();
    }

    [HttpGet("{id}")]
    public ActionResult<Place> GetAction(int id)
    {
      return _db.Places.FirstOrDefault(entry => entry.PlaceId == id);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Place place)
    {
      place.PlaceId = id;
      _db.Entry(place).State = EntityState.Modified;
      _db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var placeToDelete = _db.Places.FirstOrDefault(entry => entry.PlaceId == id);
      _db.Places.Remove(placeToDelete);
      _db.SaveChanges();
    }
  }
}