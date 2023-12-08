namespace bootcamper_helpdesk.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<GetUserResponseDto>> AddUser(AddUserRequestDto newUser);
        Task<ServiceResponse<GetUserResponseDto>> GetUser(int id);
        Task<ServiceResponse<GetUserResponseDto>> DeleteUser(int id);
        Task<ServiceResponse<GetUserResponseDto>> UpdateUser(UpdateUserRequestDto newUser);
    }
}
