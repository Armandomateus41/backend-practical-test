using System;
using System.Collections.Generic;
using BackendPracticalTest.DTOs;
using BackendPracticalTest.Models;
using BackendPracticalTest.Repositories;

namespace BackendPracticalTest.Services
{
    public class TransactionService
    {
        private readonly TransactionRepository _repository;

        public TransactionService(TransactionRepository repository)
        {
            _repository = repository;
        }

        public List<Transaction> GetAll()
        {
            return _repository.GetAll();
        }

        public void Create(TransactionDTO dto)
        {
            var transaction = new Transaction
            {
                Title = dto.Title,
                Amount = dto.Amount,
                CreatedAt = DateTime.Now
            };

            _repository.Insert(transaction);
        }

        public void Update(TransactionDTO dto)
        {
            var transaction = new Transaction
            {
                Id = dto.Id,
                Title = dto.Title,
                Amount = dto.Amount,
                CreatedAt = DateTime.Now // ou manter o original, se necessário
            };

            _repository.Update(transaction);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
