using bootcamper_helpdesk.Models;
using Microsoft.AspNetCore.Mvc;

namespace bootcamper_helpdesk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResponseController : ControllerBase
    {

        private readonly IResponseService _responseService;

        public ResponseController(IResponseService responseService)
        {
            _responseService = responseService;
        }

        [HttpGet("getSurveyResponses/{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetResponsesResponseDto>>>> GetResponses(int id)
        {
            return Ok(await _responseService.GetResponses(id));
        }

        [HttpGet("GetSingleResponse")]
        public async Task<ActionResult<ServiceResponse<List<GetResponsesResponseDto>>>> GetSingleResponse(int id, int questionId)
        {
            return Ok(await _responseService.GetSingleResponse(id, questionId));
        }

        [HttpPost("PostSurveyResponses")]
        public async Task<ActionResult<ServiceResponse<List<GetResponsesResponseDto>>>> AddResponses(List<AddResponsesRequestDto> newResponses)
        {

            return Ok(await _responseService.AddResponses(newResponses));
        }
    }
}
