using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPriceMonitor.Common.DataTransferObjects
{
    public class LastFiveStockPriceResponseDTO
    {
        public decimal Price { get; set; }
        public string DateTime { get; set; }
    }
}
