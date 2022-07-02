using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPriceMonitor.Common.DataTransferObjects
{
    public class TickerRequestDTO
    {
        [Required]
        public string TickerName { get; set; }
        [Required]
        public int PriceSourceId { get; set; }
    }
}
