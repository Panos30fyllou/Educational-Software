using Dapper.Contrib.Extensions;

namespace IES.Models.DataModels
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string? Password { get; set; }
        public UserRole Role { get; set; }
        public string Email { get; set; }
    }
}
