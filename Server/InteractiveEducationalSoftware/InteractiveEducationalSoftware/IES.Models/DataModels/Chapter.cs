using Dapper.Contrib.Extensions;

namespace IES.Models.DataModels
{
    public class Chapter
    {
        [Key]
        public int ChapterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
