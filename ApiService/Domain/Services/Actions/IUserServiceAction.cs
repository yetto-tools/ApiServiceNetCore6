using ApiService.Mapping.DTOs;

namespace ApiService.Domain.Services.Actions
{
    public interface IUserServiceAction
    {
        public Task<IEnumerable<UserDto>> GetUsersAll();
        public Task<UserDto> GetUserById(string id_usuario);
        public Task<bool> VerificatePassword(string id_usuario, string hash_password);
    }
}
