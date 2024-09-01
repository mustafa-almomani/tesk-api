using System.ComponentModel.DataAnnotations;

namespace task_2_api.DTO
{
    public class UserDTONew
    {
        public string? Username { get; set; }

        public string? Password { get; set; }

        public string? Email { get; set; }
    }
}
