using StockPriceMonitor.Entities.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace StockPriceMonitor.Entities.Models
{
    public class PriceSource : Entity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
