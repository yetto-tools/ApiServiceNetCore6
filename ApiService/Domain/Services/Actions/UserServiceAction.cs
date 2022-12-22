using Dapper;
using AutoMapper;
using ApiService.Domain.AppContext;
using ApiService.Domain.SQLQueries;
using ApiService.Security;
using ApiService.Mapping.Models;
using ApiService.Mapping.DTOs;

namespace ApiService.Domain.Services.Actions
{
    public class UserServiceAction : IUserServiceAction
    {
        private readonly ILogger<UserServiceAction> _logger;
        private readonly TesoreriaContext _context;
        private readonly IMapper _mapper;
        private readonly UserQueries _query = new();


        public UserServiceAction(ILogger<UserServiceAction> logger, TesoreriaContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetUsersAll()
        {
            using var connection = _context.CreateConnection(); 

            var users = await connection.QueryAsync<UserModel>(_query.GetUsersAll);
            _logger.LogInformation("userDto", users);
            var result = _mapper.Map<IEnumerable<UserDto>>(users);

            return result;
        }

        public async Task<UserDto> GetUserById(string id)
        {
            using var connection = _context.CreateConnection();
            var user = await connection.QuerySingleOrDefaultAsync<UserModel>(_query.GetUserById, new { id });
            var result = _mapper.Map<UserDto>(user);
            return result;
        }

        public async Task<bool> VerificatePassword(string id, string password)
        {
            using var connection = _context.CreateConnection();
            
            var user = await connection.QuerySingleOrDefaultAsync<UserModel>(_query.GetUserById, new { id });

            _logger.LogInformation("[{}]: {} ", DateTime.UtcNow, user.Contrasenia);

            var hashed = new HashPassword();

            var decode = hashed.Base64Decode(password);
            
            hashed.Password = decode;
            
            _logger.LogInformation("[{}]: {} ", DateTime.UtcNow, decode);

            var  verificated = hashed.Verificate_SHA2_256ASCII(user.Contrasenia);

            _logger.LogInformation("[{}]: {} ", DateTime.UtcNow, verificated);
            
            if (user != null && !verificated) return false;
            
            return true;
        }

    }
}
