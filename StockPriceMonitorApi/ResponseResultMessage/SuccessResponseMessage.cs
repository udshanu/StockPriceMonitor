
namespace StockPriceMonitor.Api.ResponseResultMessage
{
    public class SuccessResponseMessage
    {
        public int ResponseCode { get; set; } = 200;
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
}
