﻿using IES.Interfaces.Repositories;
using IES.Interfaces.Services;
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

        public List<Question> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Question SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Question entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Question entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
