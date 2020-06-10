using System.ComponentModel.DataAnnotations;

namespace TravelApi.Models
{
  public class Review
  {
    public int ReviewId { get; set; }

    [Required]
    [StringLength(255)]
    public string ReviewText { get; set; }

    [Required]
    [Range(0, 10, ErrorMessage = "Ratings are numbers 0 - 10")]
    public double Rating { get; set; }
    public virtual Place Place { get; set; }
    public User User { get; set; }
  }
}