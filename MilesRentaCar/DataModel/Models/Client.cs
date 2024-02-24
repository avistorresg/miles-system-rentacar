using Microsoft.EntityFrameworkCore;

namespace MilesRentaCar.DataModel.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? MobilePhone { get; set; }
        public string? OtherPhone { get; set; }
        public virtual Location? Location { get; set; }
    }
}
