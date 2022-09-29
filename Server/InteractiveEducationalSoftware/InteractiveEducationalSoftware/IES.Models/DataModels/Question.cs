namespace IES.Models.DataModels
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Description { get; set; }
        public int CorrectAnswerId { get; set; }
        public int Points { get; set; }
    }
}
