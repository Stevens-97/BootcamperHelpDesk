namespace bootcamper_helpdesk
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Response,GetResponsesResponseDto>();
            CreateMap<AddResponsesRequestDto, Response>();
        }
    }
}
