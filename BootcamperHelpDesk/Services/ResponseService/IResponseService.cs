namespace bootcamper_helpdesk.Services.ResponseService
{
    public interface IResponseService
    {
        Task<ServiceResponse<List<GetResponsesResponseDto>>> GetUserSurveyResponses(int userId, int surveyId);
        Task<ServiceResponse<GetResponsesResponseDto>> GetSingleResponse(int id, int questionId);
        Task<ServiceResponse<List<GetResponsesResponseDto>>> AddResponses(List<AddResponsesRequestDto> newResponses);
    }
}
