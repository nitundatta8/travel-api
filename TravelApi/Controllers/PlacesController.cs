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
      return _db.Places.ToList();
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
  }
}