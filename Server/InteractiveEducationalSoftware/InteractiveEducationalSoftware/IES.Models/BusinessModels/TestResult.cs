namespace IES.Models.BusinessModels
{
    public class TestResult
    {
        public int StudentId { get; set; }
        public DateTime Date { get; set; }
        public List<int> WrongQuestionIds { get; set; }
        public int Score { get; set; }
        public int StartingChapterId { get; set; }
        public int EndingChapterId { get; set; }
    }
}
