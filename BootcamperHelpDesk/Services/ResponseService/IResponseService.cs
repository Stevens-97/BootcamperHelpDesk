namespace bootcamper_helpdesk.Services.ResponseService
{
    public interface IResponseService
    {
        List<Response> GetResponses(int id);
        Response GetSingleResponse(int id, int questionId);
        List<Response> AddResponses(List<Response> newResponses);
    }
}
