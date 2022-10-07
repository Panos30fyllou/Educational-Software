namespace IES.Models.BusinessModels
{
    public class StudentLessonProgress
    {
        public int StudentId { get; set; }
        public int LessonId { get; set; }
        public bool Completed { get; set; }
        public DateTime DateCompleted { get; set; }
    }
}
