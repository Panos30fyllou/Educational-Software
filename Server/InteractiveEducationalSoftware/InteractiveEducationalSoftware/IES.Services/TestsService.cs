using IES.Interfaces.Repositories;
using IES.Interfaces.Services;
using IES.Models;
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

        public Test GenerateTest()
        {
            return new Test()
            {
                Questions = _questionRepository.SelectFive()
            };
        }

        public List<Test> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Test SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Test entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Test entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
