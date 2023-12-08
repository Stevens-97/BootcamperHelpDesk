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
            var response = await _responseService.GetResponses(id);

            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("GetSingleResponse")]
        public async Task<ActionResult<ServiceResponse<List<GetResponsesResponseDto>>>> GetSingleResponse(int id, int questionId)
        {
            var response = await _responseService.GetSingleResponse(id, questionId);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost("PostSurveyResponses")]
        public async Task<ActionResult<ServiceResponse<List<GetResponsesResponseDto>>>> AddResponses(List<AddResponsesRequestDto> newResponses)
        {
            var response = _responseService.AddResponses(newResponses);
            if(response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
