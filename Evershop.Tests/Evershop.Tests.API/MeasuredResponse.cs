using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
