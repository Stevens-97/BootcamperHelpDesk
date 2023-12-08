using bootcamper_helpdesk.Models;

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
            new User{Id = 2, FirstName = "Dani", LastName = "Smith", AutherisationLevel = 1 }
            };

        public async Task<ServiceResponse<GetUserResponseDto>> AddUser(AddUserRequestDto newUser)
        {
            var serviceResponse = new ServiceResponse<GetUserResponseDto>();

            try
            {
                var user = _mapper.Map<User>(newUser);
                user.Id = users.Max(c => c.Id + 1);
                users.Add(user);
                serviceResponse.Data = _mapper.Map<GetUserResponseDto>(user);
            } catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
           
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserResponseDto>> GetUser(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserResponseDto>();
            try
            {
                var user = _mapper.Map<GetUserResponseDto>(users.FirstOrDefault(c => c.Id == id));
                serviceResponse.Data = user;
            } catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
           
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserResponseDto>> DeleteUser(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserResponseDto>();
            try
            {
                var userToRemove = users.FirstOrDefault(c => c.Id == id) ?? throw new Exception($"User with Id {id} is not found");
                users.Remove(userToRemove);
                serviceResponse.Data = _mapper.Map<GetUserResponseDto>(userToRemove);
            } catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserResponseDto>> UpdateUser(UpdateUserRequestDto updatedUser)
        {
            var serviceResponse = new ServiceResponse<GetUserResponseDto>();

            try
            {
                var user = users.FirstOrDefault(c => c.Id == updatedUser.Id) ?? throw new Exception($"User with Id {updatedUser.Id} is not found");
                user.FirstName = updatedUser.FirstName;
                user.LastName = updatedUser.LastName;
                user.Email = updatedUser.Email;
                user.Password = updatedUser.Password;
                serviceResponse.Data = _mapper.Map<GetUserResponseDto>(user);
            } catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;

        }
    }
}
