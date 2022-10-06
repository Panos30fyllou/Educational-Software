using IES.Models.DataModels;

namespace IES.Interfaces.Repositories
{
    public interface IQuestionsRepository : ICommonRepository<Question, int>
    {
        public List<Question> SelectFive();
    }
}
