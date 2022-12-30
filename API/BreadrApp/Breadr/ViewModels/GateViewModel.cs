namespace Breadr.ViewModels
{
    public class GateViewModel
    {
        public string? GateId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public long Latitude { get; set; }
        public long Longitude { get; set; }
        public decimal Price { get; set; }
        public int UserId { get; set; }
    }
}
