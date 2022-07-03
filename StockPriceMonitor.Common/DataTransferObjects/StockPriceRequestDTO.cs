using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPriceMonitor.Common.DataTransferObjects
{
    public class StockPriceRequestDTO
    {
        [Required]
        public int TickerId { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
