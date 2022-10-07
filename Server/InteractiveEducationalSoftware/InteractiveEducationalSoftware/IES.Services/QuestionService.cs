using IES.Interfaces.Repositories;
using IES.Interfaces.Services;

namespace IES.Services
{
    public class QuestionsService : IQuestionsService
    {
        private IQuestionsRepository _questionRepository;

        public string ConnectionString { get; set; }

        public QuestionsService(IQuestionsRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
    }
}
