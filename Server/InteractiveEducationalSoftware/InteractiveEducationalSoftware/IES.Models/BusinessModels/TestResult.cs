namespace IES.Models.BusinessModels
{
    public class TestResult
    {
        public DateTime Date { get; set; }
        public List<int> WrongQuestionIds { get; set; }
        public int Score { get; set; }
    }
}
