using bootcamper_helpdesk.Dtos.User;

namespace bootcamper_helpdesk.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<AddUserRequestDto>> AddUser();
        Task<ServiceResponse<GetUserResponseDto>> GetUser(int id);
        Task<ServiceResponse<DeleteUserRequestDto>> DeleteUser();
        Task<ServiceResponse<UpdateUserRequestDto>> UpdateUser();
    }
}
