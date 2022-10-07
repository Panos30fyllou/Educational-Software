using IES.Models.DataModels;

namespace IES.Interfaces.Repositories
{
    public interface IQuestionsRepository : ICommonRepository<Question, int>
    {
        public List<Question> SelectFive(int startingChapterId, int endingChapterId);
        public void InsertWrongAnswerdQuestions(int studentId, List<int> questionIds, DateTime date);
    }
}
