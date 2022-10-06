using IES.Models.DataModels;

namespace IES.Interfaces.Services
{
    public interface IQuestionsService : ICommonService<Question, int>
    {
        public List<Question> GetQuestionsForTest();
    }
}
