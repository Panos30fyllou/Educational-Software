using Dapper.Contrib.Extensions;

namespace IES.Models.DataModels
{
    [Table("Lessons")]
    public class LessonEntity
    {
        [Key]
        public int LessonId { get; set; }
        public int ChapterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Material { get; set; }
    }
}
