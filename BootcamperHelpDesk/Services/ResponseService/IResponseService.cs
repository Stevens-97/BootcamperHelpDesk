namespace bootcamper_helpdesk.Services.ResponseService
{
    public interface IResponseService
    {
        Task<ServiceResponse<List<GetResponsesResponseDto>>> GetResponses(int id);
        Task<ServiceResponse<GetResponsesResponseDto>> GetSingleResponse(int id, int questionId);
        Task<ServiceResponse<List<GetResponsesResponseDto>>> AddResponses(List<AddResponsesRequestDto> newResponses);
    }
}
