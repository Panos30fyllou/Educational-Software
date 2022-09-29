namespace IES.Models.DataModels
{
    public class LessonEntity
    {
        public int LessonId { get; set; }
        public int ChapterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Material { get; set; }
    }
}
