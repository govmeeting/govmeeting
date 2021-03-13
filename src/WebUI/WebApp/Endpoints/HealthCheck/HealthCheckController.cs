using Microsoft.AspNetCore.Mvc;

namespace GM.WebUI.WebApp.Endpoints.HealthCheck
{
    //[Route("api/[controller]/[action]")]
    public class HealthCheckController : ApiController
    {
        /// <summary>
        /// Get Health Check
        /// </summary>
        /// <returns> { status = "healthy"} </returns>
        [HttpGet]
        public object Get()
        {
            return new { status = "healthy"};
        }
    }
}
