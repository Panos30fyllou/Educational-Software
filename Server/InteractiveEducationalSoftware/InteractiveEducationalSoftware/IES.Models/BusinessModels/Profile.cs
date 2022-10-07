using IES.Models.DataModels;

namespace IES.Models.BusinessModels
{
    public class Profile : User
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
