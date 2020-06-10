using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using TravelApi.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace TravelApi.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class ReviewsController : ControllerBase
  {
    private TravelApiContext _db;

    public ReviewsController(TravelApiContext db)
    {
      _db = db;
    }

    // Query reviews to view
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

    // Get a single review 
    [HttpGet("{id}")]
    [Route("getaction")]
    public ActionResult<Review> GetAction(int id)
    {
      return _db.Reviews.FirstOrDefault(entry => entry.ReviewId == id);
    }

    // Based on city review list will be populated
    [HttpGet]
    [Route("getreviews")]
    public ActionResult<IEnumerable<Review>> GetReview(string city)
    {
      var query = _db.Reviews.AsQueryable();
      if (city != null)
      {
        query = query.Where(entry => entry.Place.City == city);
      }
      return query.ToList();
    }

    // Posting a new city
    [HttpPost]
    public void Post([FromBody] Review review)
    {
      var claimsIdentity = this.User.Identity as ClaimsIdentity;
      var userId = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;

      var user = _db.Users.FirstOrDefault(entry => entry.Id.ToString() == userId);
      Console.WriteLine("Name --- " + user.FirstName);
      review.User = user;
      _db.Reviews.Add(review);
      _db.SaveChanges();
    }

    // Edit a review
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Review review)
    {
      review.ReviewId = id;
      _db.Entry(review).State = EntityState.Modified;
      _db.SaveChanges();
    }

    // Delete a review
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var reviewToDelete = _db.Reviews.FirstOrDefault(entry => entry.ReviewId == id);
      _db.Reviews.Remove(reviewToDelete);
      _db.SaveChanges();
    }
  }
}