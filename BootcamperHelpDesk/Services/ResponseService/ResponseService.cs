namespace bootcamper_helpdesk.Services.ResponseService
{
    public class ResponseService : IResponseService
    {

        private static List<Response> responses = new List<Response> {
            new Response(),
            new Response()
        };

        public List<Response> GetResponses(int id)
        {
            return responses;
        }

        public Response GetSingleResponse(int id, int questionId)
        {
            return responses[0];
        }

        public List<Response> AddResponses(List<Response> newResponses)
        {
            return responses;
        }
    }
}
