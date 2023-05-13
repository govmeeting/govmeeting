using Microsoft.AspNetCore.Mvc;

namespace GM.WebUI.WebApp.Endpoints.HealthCheck
{
    // When we were doing a health check during AppInit in clientapp, we were querying
    //     https://localhost:44333/api/HealthCheck/Get
    // When we are running in debug mode, this would be:
    //     https://localhost:5001/api/HealthCheck/Get

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
