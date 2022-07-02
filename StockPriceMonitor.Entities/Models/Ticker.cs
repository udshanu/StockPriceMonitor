using StockPriceMonitor.Entities.Models.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockPriceMonitor.Entities.Models
{
    public class Ticker : Entity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string TickerName { get; set; }
        [Required]
        public int PriceSourceId { get; set; }

        [ForeignKey("PriceSourceId")]
        public virtual PriceSource PriceSource { get; set; }
    }
}
