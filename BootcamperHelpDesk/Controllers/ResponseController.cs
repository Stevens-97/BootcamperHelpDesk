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
        public ActionResult<List<Response>> GetResponses(int id)
        {
            return Ok(_responseService.GetResponses(id));
        }

        [HttpGet("GetSingleResponse")]
        public ActionResult<List<Response>> GetSingleResponse(int id, int questionId)
        {
            return Ok(_responseService.GetSingleResponse(id, questionId));
        }

        [HttpPost("PostSurveyResponses")]
        public ActionResult<List<Response>> AddResponses(List<Response> newResponses)
        {

            return Ok(_responseService.AddResponses(newResponses));
        }
    }
}
