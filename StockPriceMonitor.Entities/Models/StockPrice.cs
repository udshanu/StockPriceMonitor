using StockPriceMonitor.Entities.Models.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockPriceMonitor.Entities.Models
{
    public class StockPrice : Entity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int TickerId { get; set; }
        [Required]
        public decimal Price { get; set; }

        [ForeignKey("TickerId")]
        public virtual Ticker Ticker { get; set; }
    }
}
