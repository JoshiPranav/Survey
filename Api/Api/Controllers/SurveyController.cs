using System;
using System.Threading.Tasks;
using Api.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("api/[Controller]")]
    public class SurveyController : ControllerBase
    {
        private readonly ILogger<SurveyController> _logger;
        private readonly ISurveyService _surveyService;

        public SurveyController(ISurveyService surveyService, ILogger<SurveyController> logger)
        {
            _logger = logger;
            _surveyService = surveyService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var surveyVM = await _surveyService.GetSurveyAsync(id);
                if (surveyVM == null)
                {
                    return NotFound(string.Format("Survey with {0} not found", id));
                }
                return Ok(surveyVM);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Please supply valid data");
            }
        }
    }
}
