using bootcamper_helpdesk.Data;
using bootcamper_helpdesk.Models;

namespace bootcamper_helpdesk.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public UserService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<GetUserResponseDto>> AddUser(AddUserRequestDto newUser)
        {
            var serviceResponse = new ServiceResponse<GetUserResponseDto>();

            try
            {
                var user = _mapper.Map<User>(newUser);
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
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
                var dbResponse = await _context.Users.FindAsync(id) ?? throw new Exception($"User with id {id} was not found");
                var user = _mapper.Map<GetUserResponseDto>(dbResponse);
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
                var dbResponse = await _context.Users.FindAsync(id) ?? throw new Exception($"User with Id {id} was not found");
                _context.Remove(dbResponse);
                serviceResponse.Data = _mapper.Map<GetUserResponseDto>(dbResponse);
            } catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserResponseDto>> UpdateUser(GetUserResponseDto updatedUser)
        {
            var serviceResponse = new ServiceResponse<GetUserResponseDto>();

            try
            {
                var dbResponse = await _context.Users.FindAsync(updatedUser.Id) ?? throw new Exception($"User with the id {updatedUser.Id} was not found");
                dbResponse.FirstName = updatedUser.FirstName;
                dbResponse.LastName = updatedUser.LastName;
                dbResponse.Email = updatedUser.Email;
                dbResponse.Password = updatedUser.Password;
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetUserResponseDto>(updatedUser);
            } catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;

        }
    }
}
