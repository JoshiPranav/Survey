using System;
using System.Threading.Tasks;
using Api.Services;
using Api.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserSurveyController : ControllerBase
    {
        private readonly IUserSurveyService _userSurveyService;
        private readonly ILogger<UserSurveyController> _logger;

        public UserSurveyController(IUserSurveyService userSurveyService, ILogger<UserSurveyController> logger)
        {
            _userSurveyService = userSurveyService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserSurveyViewModel userSurvey)
        {
            try
            {
                if (userSurvey == null)
                {
                    return BadRequest("Please supply valid data");
                }
                var recordsInserted = await _userSurveyService.SaveUserSurveyAsync(userSurvey);
                return Created("", recordsInserted);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex; //TODO: error handling middleware
            }
        }
    }
}
