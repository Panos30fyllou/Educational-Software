using IES.Interfaces.Repositories;
using IES.Interfaces.Services;
using IES.Models;
using IES.Models.DataModels;

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
        public List<Question> GetQuestionsForTest()
        {
            return _questionRepository.SelectFive();
        }

        public void Insert(Question question)
        {
            _questionRepository.Insert(question);
        }

        public void Delete(int id)
        {
            var question = _questionRepository.SelectById(id);
            if (question == null)
                throw new BusinessException("Question not found!");
            _questionRepository.Delete(question);
        }

        public List<Question> SelectAll()
        {
            var questionsList = _questionRepository.SelectAll();
            return questionsList;
        }

        public Question SelectById(int id)
        {
            var question = _questionRepository.SelectById(id);
            if (question == null)
                throw new BusinessException("Question not found!");
            return question;
        }

        public void Update(Question question)
        {
            _questionRepository.SelectById(question.QuestionId);
            _questionRepository.Update(question);
        }


    }

}
