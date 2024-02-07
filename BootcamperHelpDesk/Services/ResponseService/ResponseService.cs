namespace bootcamper_helpdesk.Services.ResponseService
{
    public class ResponseService : IResponseService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ResponseService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetResponsesResponseDto>>> GetUserSurveyResponses(int userId, int surveyId)
        {
            var serviceResponse = new ServiceResponse<List<GetResponsesResponseDto>>();
            try
            {
                var dbResponses = await _context.Responses.Where(c=> c.SurveryId == surveyId && c.UserId == userId).ToListAsync() ?? throw new Exception($"No responses found for user {userId} for the survey {surveyId}");
                serviceResponse.Data = dbResponses.Select(c => _mapper.Map<GetResponsesResponseDto>(c)).ToList();

            } catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetResponsesResponseDto>> GetSingleResponse(int id, int questionId)
        {
            var serviceResponse = new ServiceResponse<GetResponsesResponseDto>();
            try
            {
                var dbResponse = await _context.Responses.FindAsync(id) ?? throw new Exception($"No response with an id of {id} was found");
                serviceResponse.Data = _mapper.Map<GetResponsesResponseDto>(dbResponse);
            } catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetResponsesResponseDto>>> AddResponses(List<AddResponsesRequestDto> newResponses)
        {
            
            var serviceResponse = new ServiceResponse<List<GetResponsesResponseDto>>();
            try
            {
                var dbResponses = await _context.Responses.ToListAsync();

                var updatedResponses = _mapper.Map<List<Response>>(newResponses);
                foreach (Response singleResponse in updatedResponses)
                {
                    dbResponses.Add(singleResponse);
                }
                await _context.SaveChangesAsync();
                serviceResponse.Data = dbResponses.Select(c => _mapper.Map<GetResponsesResponseDto>(c)).ToList();
            } catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
