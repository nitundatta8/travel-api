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
  public class ReviewController : ControllerBase
  {
    private TravelApiContext _db;

    public ReviewController(TravelApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Review>> Get(string reviewtext, double rating)
    {
      var query = _db.Reviews.AsQueryable();

      if (reviewtext != null)
      {
        query = query.Where(entry => entry.ReviewText == reviewtext);
      }
      if (rating != 0)
      {
        query = query.Where(entry => entry.Rating == rating);
      }
      return query.ToList();
    }
  }
}