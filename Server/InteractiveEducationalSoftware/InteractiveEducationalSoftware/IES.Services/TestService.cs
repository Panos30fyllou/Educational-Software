using IES.Interfaces.Repositories;
using IES.Interfaces.Services;
using IES.Models;
using IES.Models.DataModels;

namespace IES.Services
{
    public class TestsService : ITestsService
    {
        private IRepository<Test, int> _testRepository;
        private IQuestionsRepository _questionRepository;

        public string ConnectionString { get; set; }

        public TestsService(IRepository<Test, int> testRepository, IQuestionsRepository questionRepository)
        {
            _testRepository = testRepository;
            _questionRepository = questionRepository;

        }

        public Test GenerateTest()
        {
            return new Test() { 
                Questions = _questionRepository.SelectFive() 
            };
        }

        public void Insert(Test test)
        {
            _testRepository.Insert(test);
        }

        public void Delete(int id)
        {
            var test = _testRepository.SelectById(id);
            if (test == null)
                throw new BusinessException("Test not found!");
            _testRepository.Delete(test);
        }

        public List<Test> SelectAll()
        {
            var testsList = _testRepository.SelectAll();
            return testsList;
        }

        public Test SelectById(int id)
        {
            var test = _testRepository.SelectById(id);
            if (test == null)
                throw new BusinessException("Test not found!");
            return test;
        }

        public void Update(Test test)
        {
            _testRepository.SelectById(test.TestId);
            _testRepository.Update(test);
        }
    }

}
