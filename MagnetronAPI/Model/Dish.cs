namespace MagnetronAPI.Model
{
    public class Dish
    {
        public int DishId { get; set; }
        public string? Name { get; set; }
        public List<Prep>? Preps { get; set; }
    }
}
