using System.ComponentModel.DataAnnotations;

namespace StockPriceMonitor.Common.DataTransferObjects
{
    public class PriceSourceRequestDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
