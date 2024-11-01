using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evershop.Tests.API
{
    public class MeasuredResponse<TReturnType> : MeasuredResponse
     where TReturnType : class
    {
        private readonly RestResponse<TReturnType> _restResponse;

        public MeasuredResponse(RestResponse<TReturnType> restResponse, TimeSpan executionTime)
            : base(restResponse, executionTime)
        {
            _restResponse = restResponse;
        }

        public TReturnType Data { get => _restResponse.Data; set => _restResponse.Data = value; }
    }
}
