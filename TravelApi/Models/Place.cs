using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelApi.Models
{
  public class Place
  {
    public int PlaceId { get; set; }

    [Required]
    [StringLength(255)]
    public string City { get; set; }

    [Required]
    [StringLength(255)]
    public string Country { get; set; }

    [Required]
    [Range(0, 10, ErrorMessage = "Ratings are numbers 0 - 10")]
    public double Rating { get; set; }

    public virtual ICollection<Review> Reviews { get; set; }
    public Place()
    {
      this.Reviews = new HashSet<Review>();
    }
  }
}