namespace bootcamper_helpdesk.Services.SurveyQuestionService
{
    public interface ISurveyQuestionService
    {
        Task<ServiceResponse<GetSurveyQuestionDto>> GetQuestion(int questionId);
        Task<ServiceResponse<GetSurveyQuestionDto>> UpdateQuestion(AddSurveyQuestionDto updatedSurveyQuestion);
        Task<ServiceResponse<GetSurveyQuestionDto>> DeleteQuestion(int questionId);
        Task<ServiceResponse<GetSurveyQuestionDto>> AddQuestion(AddSurveyQuestionDto newSurveyQuestion);
        Task<ServiceResponse<List<GetSurveyQuestionDto>>> GetSurvey(int surveyId);
        Task<ServiceResponse<List<GetSurveyQuestionDto>>> CreateSurvey(List<AddSurveyQuestionDto> newSurvey);
        Task<ServiceResponse<List<GetSurveyQuestionDto>>> UpdateSurvey(List<GetSurveyQuestionDto> updatedSurvey);
        Task<ServiceResponse<List<GetSurveyQuestionDto>>> DeleteSurvey(int surveyId);

    }
}
