using Dapper.Contrib.Extensions;

namespace IES.Models.DataModels
{
    public class Test
    {
        [Key]
        public int TestId { get; set; }
        public List<Question> Questions { get; set; }
    }
}
