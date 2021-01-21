using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GM.WebUI.WebApp.Endpoints.HealthCheck

{
    /// <summary>
    /// Check if server is alive and well. 
    /// </summary>
    [Route("api/[controller]")]
    public class HealthCheckController : ApiController
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

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> GetWeather()
        {
            return await Mediator.Send(new GetWeatherForecastsQuery());
        }

    }
}
