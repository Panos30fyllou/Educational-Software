using IES.Models;

namespace IES.Interfaces.Repositories
{
    public interface IQuestionsRepository : IRepository<Question, int>
    {
        public List<Question> SelectFive();
    }
}
