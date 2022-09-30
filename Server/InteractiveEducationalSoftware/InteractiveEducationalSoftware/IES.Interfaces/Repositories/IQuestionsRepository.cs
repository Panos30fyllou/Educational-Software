using IES.Models.DataModels;

namespace IES.Interfaces.Repositories
{
    public interface IQuestionsRepository : IRepository<Question, int>
    {
        public List<Question> SelectFive();
    }
}
