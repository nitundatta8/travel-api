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
    public ActionResult<IEnumerable<Review>> Get(string ReviewText, double Rating)
    {
      return _db.Reviews.ToList();
    }
  }
}