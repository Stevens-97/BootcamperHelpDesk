namespace bootcamper_helpdesk.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;

        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }

        private static List<User> users = new List<User> {
            new User{Id = 1, FirstName = "Elliott", LastName = "Stevens", AutherisationLevel = 1},
            new User{Id = 2, FirstName = "Elliott", LastName = "Stevens", AutherisationLevel = 1 }
            };

        public async Task<ServiceResponse<AddUserRequestDto>> AddUser()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<GetUserResponseDto>> GetUser(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserResponseDto>();

            var user = _mapper.Map<GetUserResponseDto>(users.FirstOrDefault(c => c.Id == id));

            serviceResponse.Data = user;
            return serviceResponse;
        }

        public async Task<ServiceResponse<DeleteUserRequestDto>> DeleteUser()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<UpdateUserRequestDto>> UpdateUser()
        {
            throw new NotImplementedException();
        }
    }
}
