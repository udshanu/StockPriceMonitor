using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPriceMonitor.Common.DataTransferObjects
{
    public class StockPriceResponseDTO
    {
        public int Id { get; set; }
        public int TickerId { get; set; }
        public decimal Price { get; set; }
    }
}
