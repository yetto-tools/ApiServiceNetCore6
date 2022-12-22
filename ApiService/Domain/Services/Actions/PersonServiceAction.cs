using Dapper;
using AutoMapper;
using ApiService.Domain.AppContext;
using ApiService.Domain.SQLQueries;
using ApiService.Security;
using ApiService.Mapping.Models;
using ApiService.Mapping.DTOs;

namespace ApiService.Domain.Services.Actions
{
    public class PersonServiceAction
    {
        private readonly TesoreriaContext _context;
        private readonly PersonQueries _query = new();
        private readonly ILogger<PersonServiceAction> _logger;
        private readonly IMapper _mapper;
        public PersonServiceAction(TesoreriaContext context, ILogger<PersonServiceAction> logger, IMapper mapper) : base()
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PersonDto>> GetPeopleAll()
        {
            using var connection = _context.CreateConnection();

            var users = await connection.QueryAsync<PersonModel>(_query.GetPeopleAll);
            _logger.LogInformation("userDto", users);
            var result = _mapper.Map<IEnumerable<PersonDto>>(users);
            return result;
        }
    }
}
