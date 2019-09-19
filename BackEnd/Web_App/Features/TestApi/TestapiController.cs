using Microsoft.AspNetCore.Mvc;

namespace GM.WebApp.Features.Meetings
{
    [Route("api/[controller]")]
    public class TestapiController : Controller
    {

        [HttpGet("{testId}")]
        public string Get(int testId)
        {
            string ret = testId.ToString();
            return ret;
        }
    }
}
