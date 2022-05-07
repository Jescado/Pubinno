using System.ComponentModel.DataAnnotations;

namespace Pubinno.Models
{
    public class LocationUpdateViewModel
    {
        [Required]
        public int id { get; set; }
        public string address { get; set; }
        [StringLength(100, ErrorMessage = "Name length can't be more than 100.")]
        public string name { get; set; }
        public DateTime openingTime { get; set; }
        public DateTime closingTime { get; set; }
    }
}
