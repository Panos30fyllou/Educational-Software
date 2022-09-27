using IES.Models;

namespace IES.Interfaces.Services
{
    public interface IQuestionsService : IService<Question, int>
    {
        public List<Question> GetQuestionsForTest();
    }
}
