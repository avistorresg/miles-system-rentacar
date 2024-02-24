namespace MilesRentaCar.DataModel.Models
{
    public class Market
    {
        public int Id { get; set; }
        public Location? ClientLocation { get; set; }
        public Location? ReturnLocation { get; set; }
        public Vehicle? Vehicle { get; set; }
        public string? MarketArea { get; set; }
    }
}
