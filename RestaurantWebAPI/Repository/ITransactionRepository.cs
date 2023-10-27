using RestaurantWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebAPI.Repository
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Object>> GetTransactions();
        Task<Transaction> AddTransaction(Transaction transaction);
        Task<Transaction> UpdateTransaction(Transaction transaction);
        Task DeleteTransaction(int transactionId);
    }
}
