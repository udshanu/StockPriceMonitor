using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockPriceMonitor.Api.ResponseResultMessage
{
    public class ErrorResponseMessage
    {
        public int ResponseCode { get; set; } = 500;
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
}
