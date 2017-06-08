using Microsoft.AspNetCore.Mvc;
using SampleManager.Core.Interfaces;
using SampleManager.Core.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class SamplesController : Controller
    {
        private readonly ISampleQueryService _sampleQueryService;
        private readonly ISampleDataService _sampleDataService;

        public SamplesController(ISampleQueryService sampleQueryService, ISampleDataService sampleDataService)
        {
            _sampleQueryService = sampleQueryService;
            _sampleDataService = sampleDataService;
        }

        // GET: api/samples
        [HttpGet]
        public IActionResult Get()
        {
            var results = _sampleQueryService.GetAllSamples();

            return Ok(results);
        }

        // GET: api/samples/status?statusId=<statusId>
        [HttpGet("status")]
        public IActionResult Get([FromQuery] int statusId)
        {
            var results = _sampleQueryService.GetSamplesByStatusId(statusId);

            return Ok(results);
        }

        // GET: api/samples/name?nameSearch=<nameSearch>
        [HttpGet("name")]
        public IActionResult Get([FromQuery] string nameSearch)
        {
            var results = _sampleQueryService.GetSamplesByUser(nameSearch);

            return Ok(results);
        }

        public IActionResult Post([FromBody] SampleViewModel sample)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _sampleDataService.SaveSample(sample);

            return Ok();
        }
    }
}
