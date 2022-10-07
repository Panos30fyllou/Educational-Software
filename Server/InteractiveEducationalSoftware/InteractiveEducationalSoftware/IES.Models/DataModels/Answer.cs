using Dapper.Contrib.Extensions;

namespace IES.Models.DataModels
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        //public int RelatedQuestionId { get; set; }
        public string Description { get; set; }
    }
}
