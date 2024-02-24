namespace MilesRentaCar.DataModel.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string? Model { get; set; }
        public string? Brand { get; set; }
        public string? Colour { get; set; }
        public string? CarriagePlate { get; set; }
        public Location? PickupLocation { get; set; }
        public Location? ReturnLocation { get; set; }
    }
}
