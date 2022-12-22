using ApiService.Domain.Services.Actions;

namespace ApiService.Security
{
    public interface IAuthentication:IUserServiceAction
    {
        string Name { get; }
        string Password { get; }

    }
}
