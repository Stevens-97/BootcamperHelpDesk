namespace bootcamper_helpdesk
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Response,GetResponsesResponseDto>();
            CreateMap<AddResponsesRequestDto, Response>();
            CreateMap<User, GetUserResponseDto>();
            CreateMap<AddUserRequestDto, User>();
            CreateMap<AddSurveyQuestionDto, SurveyQuestion>();
            CreateMap<SurveyQuestion, GetSurveyQuestionDto>();
            CreateMap<GetSurveyQuestionDto, SurveyQuestion>();

        }
    }
}
