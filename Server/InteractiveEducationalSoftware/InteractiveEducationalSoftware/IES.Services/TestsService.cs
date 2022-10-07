using IES.Interfaces.Repositories;
using IES.Interfaces.Services;
using IES.Models;
using IES.Models.BusinessModels;
using IES.Models.DataModels;

namespace IES.Services
{
    public class TestsService : ITestsService
    {
        private ITestsRepository _testRepository;
        private IQuestionsRepository _questionRepository;

        public string ConnectionString { get; set; }

        public TestsService(ITestsRepository testRepository, IQuestionsRepository questionRepository)
        {
            _testRepository = testRepository;
            _questionRepository = questionRepository;

        }

        public Test GenerateTest(int startingChapterId, int endingChapterId)
        {
            return new Test()
            {
                Questions = _questionRepository.SelectFive(startingChapterId, endingChapterId)
            };
        }

        public void SubmitResult(TestResult result)
        {
            _questionRepository.InsertWrongAnswerdQuestions(result.StudentId, result.WrongQuestionIds, result.Date);
            _testRepository.SaveTestResult(result);
        }
    }
}
