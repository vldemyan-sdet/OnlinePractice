namespace Evershop.Tests.API
{
    public class MeasuredResponse
    {
        public MeasuredResponse(RestResponse restResponse, TimeSpan executionTime)
        {
            Response = restResponse;
            ExecutionTime = executionTime;
        }

        public TimeSpan ExecutionTime { get; set; }
        public RestResponse Response { get; set; }
    }
}
