using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using BackendPracticalTest.Models;

namespace BackendPracticalTest.Repositories
{
    public class TransactionRepository
    {
        private readonly IDbConnection _connection;

        public TransactionRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public List<Transaction> GetAll()
        {
            _connection.Open();

            var sql = "SELECT * FROM transactions ORDER BY id DESC";
            var result = _connection.Query<Transaction>(sql).ToList();

            _connection.Close();
            return result;
        }

        public Transaction GetById(int id)
        {
            _connection.Open();

            var sql = "SELECT * FROM transactions WHERE id = :Id";
            var result = _connection.QueryFirstOrDefault<Transaction>(sql, new { Id = id });

            _connection.Close();
            return result;
        }

        public void Insert(Transaction transaction)
        {
            _connection.Open();

            var sql = @"
                INSERT INTO transactions (title, amount, created_at)
                VALUES (:Title, :Amount, :CreatedAt)
            ";

            _connection.Execute(sql, transaction);
            _connection.Close();
        }

        public void Update(Transaction transaction)
        {
            _connection.Open();

            var sql = @"
                UPDATE transactions
                SET title = :Title,
                    amount = :Amount
                WHERE id = :Id
            ";

            _connection.Execute(sql, transaction);
            _connection.Close();
        }

        public void Delete(int id)
        {
            _connection.Open();

            var sql = "DELETE FROM transactions WHERE id = :Id";
            _connection.Execute(sql, new { Id = id });

            _connection.Close();
        }

        public bool Exists(int id)
        {
            _connection.Open();

            var sql = "SELECT COUNT(*) FROM transactions WHERE id = :Id";
            var count = _connection.ExecuteScalar<int>(sql, new { Id = id });

            _connection.Close();
            return count > 0;
        }
    }
}
