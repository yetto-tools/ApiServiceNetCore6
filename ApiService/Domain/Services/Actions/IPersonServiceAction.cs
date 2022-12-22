using ApiService.Mapping.DTOs;

namespace ApiService.Domain.Services.Actions
{
    public interface IPersonServiceAction
    {
        public Task<IEnumerable<PersonDto>> GetPeopleAll();
        public Task<PersonDto> GetUserById(string cui);

    }
}
