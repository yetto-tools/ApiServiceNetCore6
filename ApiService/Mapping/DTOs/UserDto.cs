using System.ComponentModel.DataAnnotations;

namespace ApiService.Mapping.DTOs
{
    public class UserDto
    {
        [Required]
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public byte IsSuperAdmin { get; set; }
        public byte Active { get; set; }
    }
}
