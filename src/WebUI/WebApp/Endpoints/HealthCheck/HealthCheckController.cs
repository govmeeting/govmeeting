using Microsoft.AspNetCore.Mvc;

namespace GM.WebUI.WebApp.Features.Meetings
{
    /// <summary>
    /// Check if server is alive and well. 
    /// </summary>
    [Route("api/[controller]")]
    public class HealthCheckController : Controller
    {
        // TODO This is temporary till we implement calling ApiHealthCheck

        /// <summary>
        /// Get server status
        /// </summary>
        /// <param name="testId">Send any interger.</param>
        /// <returns>It should return the integer times 2.</returns>
        [HttpGet("{testId}")]
        public string Get(int testId)
        {
            int timesTwo = testId * 2;
            string answer = timesTwo.ToString();
            return $"{testId} times 2 = {answer}";
        }
    }
}
