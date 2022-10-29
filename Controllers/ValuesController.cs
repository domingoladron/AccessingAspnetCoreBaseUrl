using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccessingAspnetCoreBaseUrl.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        [HttpGet("")]
        public async Task<IActionResult> GetValues()
        {
            var results = new List<string>
            {
                "one",
                "two",
                "three",
                "four",
                "five"
            };
            return await Task.FromResult(Ok(results));
        }
    }
}
