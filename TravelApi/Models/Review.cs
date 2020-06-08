

namespace TravelApi.Models
{
  public class Review
  {
    public int ReviewId { get; set; }
    public string ReviewText { get; set; }
    public double Rating { get; set; }

    public int PlaceId { get; set; }
    public virtual Place Place { get; set; }


  }
}