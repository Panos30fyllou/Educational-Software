using Dapper.Contrib.Extensions;

namespace IES.Models.DataModels
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
