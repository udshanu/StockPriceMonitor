using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPriceMonitor.Common.DataTransferObjects
{
    public class TickerResponseDTO
    {
        public int Id { get; set; }
        public string TickerName { get; set; }
        public int PriceSourceId { get; set; }
    }
}
