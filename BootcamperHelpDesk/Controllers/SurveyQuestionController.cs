using bootcamper_helpdesk.Dtos.Question;

namespace bootcamper_helpdesk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SurveyQuestionController : ControllerBase
    {
        readonly ISurveyQuestionService _questionService;
        public SurveyQuestionController(ISurveyQuestionService questionService)
        {
            _questionService = questionService;
        }

    

        [HttpGet("GetQuestion")]
        public async Task<ActionResult<ServiceResponse<GetSurveyQuestionDto>>> GetQuestion(int questionId)
        {
            var response = await _questionService.GetQuestion(questionId);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPatch("UpdateQuestion")]
        public async Task<ActionResult<ServiceResponse<GetSurveyQuestionDto>>> UpdateQuestion(GetSurveyQuestionDto updatedQuestion)
        {
            var response = await _questionService.UpdateQuestion(updatedQuestion);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("DeleteQuestion")]
        public async Task<ActionResult<ServiceResponse<GetSurveyQuestionDto>>> DeleteQuestion(int questionId)
        {
            var response = await _questionService.DeleteQuestion(questionId);
            if(response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost("CreateQuestion")]
        public async Task<ActionResult<ServiceResponse<GetSurveyQuestionDto>>> AddQuestion(GetSurveyQuestionDto question)
        {
            var response = await _questionService.AddQuestion(question);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("GetSurvey")]
        public async Task<ActionResult<ServiceResponse<List<GetSurveyQuestionDto>>>> GetSurvey(int surveyId)
        {
            var response = await _questionService.GetSurvey(surveyId);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost("CreateSurvey")]
        public async Task<ActionResult<ServiceResponse<List<GetSurveyQuestionDto>>>> CreateSurvey()
        {
            var response = await _questionService.CreateSurvey();
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("DeleteSurvey")]
        public async Task<ActionResult<ServiceResponse<List<GetSurveyQuestionDto>>>> DeleteSurvey(int surveyId)
        {
            var response = await _questionService.DeleteSurvey(surveyId);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPatch("UpdateSurvey")]
        public async Task<ActionResult<ServiceResponse<List<GetSurveyQuestionDto>>>> UpdateSurvey(List<GetSurveyQuestionDto> updatedSurvey)
        {
            var response = await _questionService.UpdateSurvey(updatedSurvey);

            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}
