using Microsoft.AspNetCore.Mvc;
using TestingApiService.Models;
using TestingApiService.Repository;

namespace TestingApiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestRunsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<TestRunsController> _logger;

        public TestRunsController(ILogger<TestRunsController> logger)
        {
            _logger = logger;
        }

        //[HttpPost(Name = "LogTestRun")]
        //public void Post(TestRunModel testRunModel)
        //{
        //    var dbRepo = new TestRunsRepository();
        //    dbRepo.LogTestExecutionTime(testRunModel);
        //}

        [HttpPost(Name = "LogTestRun")]
        public void Post(TestRunModel testRunModel)
        {
            var dbRepo = new TestRunsRepository();
            
            //testRunModel.TestName = "test2";
            //testRunModel.StartTime = DateTime.Now;
            //testRunModel.EndTime = DateTime.Now;
            //testRunModel.Result = "test2";
            dbRepo.LogTestExecutionTime(testRunModel);
        }
    }
}
