namespace Pubinno.Models
{
    public class LocationUpdateViewModel
    {
        public int id { get; set; }
        public string address { get; set; }
        public string name { get; set; }
        public DateTime openingTime { get; set; }
        public DateTime closingTime { get; set; }
    }
}
