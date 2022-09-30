namespace IES.Models.DataModels
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public int RelatedQuestionId { get; set; }
        public string Description { get; set; }
    }
}
