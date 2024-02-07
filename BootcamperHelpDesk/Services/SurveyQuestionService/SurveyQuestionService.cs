using bootcamper_helpdesk.Models;

namespace bootcamper_helpdesk.Services.SurveyQuestionService
{
    public class SurveyQuestionService : ISurveyQuestionService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public SurveyQuestionService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<GetSurveyQuestionDto>> AddQuestion(AddSurveyQuestionDto newSurveyQuestion)
        {
            var serviceResponse = new ServiceResponse<GetSurveyQuestionDto>();
            try
            {
                var dbResponse = _context.SurveyQuestions;
                var question = _mapper.Map<SurveyQuestion>(newSurveyQuestion);
                var surveyFound = dbResponse.Where(question => question.SurveyId == newSurveyQuestion.SurveyId);
                if (surveyFound.Any())
                {
                    _context.SurveyQuestions.Add(question);
                    await _context.SaveChangesAsync();
                    var newQuestionId = question.Id;
                    var addedQuestion = await _context.SurveyQuestions.FindAsync(newQuestionId);
                    serviceResponse.Data = _mapper.Map<GetSurveyQuestionDto>(addedQuestion);
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
        private static string GenerateUniqueSurveyId()
        {
            var prefix = "SURV";
            var timestamp = DateTime.UtcNow.Ticks; // Ticks give a fine-grained timestamp
            var randomPart = new Random().Next(1000, 9999); // Random number for additional uniqueness

            return $"{prefix}-{timestamp}-{randomPart}";
        }

        public async Task<ServiceResponse<List<GetSurveyQuestionDto>>> CreateSurvey(List<AddSurveyQuestionDto> newSurvey)
        {
            var serviceResponse = new ServiceResponse<List<GetSurveyQuestionDto>>();
            try
            {
                var surveyId = GenerateUniqueSurveyId();
                foreach (AddSurveyQuestionDto newQuestion in newSurvey)
                {
                    var question = _mapper.Map<SurveyQuestion>(newQuestion);
                    newQuestion.SurveyId = surveyId;
                    _context.SurveyQuestions.Add(question);
                }
                await _context.SaveChangesAsync();
                var addedSurvey = await _context.SurveyQuestions.Where(question => question.SurveyId == surveyId).ToListAsync() ?? throw new Exception($"No questions with the survey id of {surveyId} was found.");
                serviceResponse.Data = _mapper.Map<List<GetSurveyQuestionDto>>(addedSurvey);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetSurveyQuestionDto>> DeleteQuestion(int questionId)
        {
            var serviceResponse = new ServiceResponse<GetSurveyQuestionDto>();
            try
            {
                var dbResponse = await _context.SurveyQuestions.FindAsync(questionId) ?? throw new Exception($"Question with the Id {questionId} was not found");
                _context.SurveyQuestions.Remove(dbResponse);
                serviceResponse.Data = _mapper.Map<GetSurveyQuestionDto>(dbResponse);
            } catch (Exception ex)
            {
                serviceResponse.Success=false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetSurveyQuestionDto>>> DeleteSurvey(string surveyId)
        {
            var serviceResponse = new ServiceResponse<List<GetSurveyQuestionDto>>();
            try
            {
                var dbResponse = await _context.SurveyQuestions.Where(question => question.SurveyId == surveyId).ToListAsync() ?? throw new Exception($"No questions with the survey id of {surveyId} was found.");
                foreach (var dbQuestion in dbResponse)
                {
                    _context.SurveyQuestions.Remove(dbQuestion);
                }
                serviceResponse.Data = _mapper.Map<List<GetSurveyQuestionDto>>(dbResponse);
            }
            catch (Exception ex)
            {
                serviceResponse.Success=false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetSurveyQuestionDto>> GetQuestion(int questionId)
        {
            var serviceResponse = new ServiceResponse<GetSurveyQuestionDto>();
            try
            {
                var dbResponse = await _context.SurveyQuestions.FindAsync(questionId) ?? throw new Exception($"Question with the Id {questionId} was not found.");
                serviceResponse.Data = _mapper.Map<GetSurveyQuestionDto>(dbResponse);
            } catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetSurveyQuestionDto>>> GetSurvey(string surveyId)
        {
            var serviceResponse = new ServiceResponse<List<GetSurveyQuestionDto>>();
            try
            {
                var dbResponse = await _context.SurveyQuestions.Where(c => c.SurveyId == surveyId).ToListAsync() ?? throw new Exception($"No questions with the survey id of {surveyId} was found.");
                foreach (var question  in dbResponse)
                {
                    
                }
                serviceResponse.Data = _mapper.Map<List<GetSurveyQuestionDto>>(dbResponse);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetSurveyQuestionDto>> UpdateQuestion(GetSurveyQuestionDto getQuestionDto)
        {
            var serviceResponse = new ServiceResponse<GetSurveyQuestionDto>();
            try
            {
                var dbResponse = await _context.SurveyQuestions.FindAsync()
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
        }


        public Task<ServiceResponse<List<GetSurveyQuestionDto>>> UpdateSurvey(List<GetSurveyQuestionDto> updatedSurvey)
        {
            var serviceResponse = new ServiceResponse<GetSurveyQuestionDto>();
            try
            {

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
        }
    }
}
