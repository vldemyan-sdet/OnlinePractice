using Microsoft.AspNetCore.Mvc;
using TestingApiService.Models;
using TestingApiService.Repository;

namespace TestingApiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestRunsController : ControllerBase
    {
        private readonly ILogger<TestRunsController> _logger;

        public TestRunsController(ILogger<TestRunsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public void Post(TestRunModel testRunModel)
        {
            var dbRepo = new TestRunsRepository();
            dbRepo.LogTestExecutionTime(testRunModel);
        }
    }
}
