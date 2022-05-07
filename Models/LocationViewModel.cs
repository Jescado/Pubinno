using System.ComponentModel.DataAnnotations;

namespace Pubinno.Models
{
    public class LocationViewModel
    {
        [Required]
        [StringLength(300)]
        public string address { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100.")]
        public string name { get; set; }
        public DateTime openingTime { get; set; }
        public DateTime closingTime { get; set; }
    }
}
