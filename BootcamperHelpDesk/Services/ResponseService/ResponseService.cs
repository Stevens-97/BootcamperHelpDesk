using bootcamper_helpdesk.Models;

namespace bootcamper_helpdesk.Services.ResponseService
{
    public class ResponseService : IResponseService
    {
        private readonly IMapper _mapper;

        public ResponseService(IMapper mapper)
        {
            _mapper = mapper;
        }

        private static List<Response> responses = new List<Response> {
            new Response(),
            new Response()
        };

        public async Task<ServiceResponse<List<GetResponsesResponseDto>>> GetResponses(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetResponsesResponseDto>>();
            serviceResponse.Data = responses.Select(c => _mapper.Map<GetResponsesResponseDto>(c)).ToList();  
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetResponsesResponseDto>> GetSingleResponse(int id, int questionId)
        {
            var serviceResponse = new ServiceResponse<GetResponsesResponseDto>();
            serviceResponse.Data = _mapper.Map<GetResponsesResponseDto>(responses);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetResponsesResponseDto>>> AddResponses(List<AddResponsesRequestDto> newResponses)
        {
            
            var serviceResponse = new ServiceResponse<List<GetResponsesResponseDto>>();

            var updatedResponses = _mapper.Map<List<Response>>(newResponses);
            foreach (Response singleResponse in updatedResponses)
            {
                singleResponse.Id = responses.Max(c => c.Id) + 1;
                responses.Add(singleResponse);
            }
            serviceResponse.Data = responses.Select(c => _mapper.Map<GetResponsesResponseDto>(c)).ToList();

            return serviceResponse;
        }
    }
}
