using Microsoft.EntityFrameworkCore;
using RestaurantWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebAPI.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext appDbContext;
        public TransactionRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Transaction> AddTransaction(Transaction transaction)
        {
            var result = await appDbContext.Transactions.AddAsync(transaction);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteTransaction(int transactionId)
        {
            var result = await appDbContext.Transactions.FirstOrDefaultAsync(e => e.TransactionId == transactionId);
            if (result != null)
            {
                appDbContext.Transactions.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Object>> GetTransactions()
        {
            var query = from transaction in appDbContext.Transactions
                        join transactionDetail in appDbContext.TransactionDetails
                        on transaction.TransactionId equals transactionDetail.TransactionId
                        select new
                        {
                            Transaction = transaction,
                            TransactionDetail = transactionDetail
                        };
            return await query.ToListAsync();
        }

        public async Task<Transaction> UpdateTransaction(Transaction transaction)
        {
            var result = await appDbContext.Transactions.FirstOrDefaultAsync(e => e.TransactionId == transaction.TransactionId);
            if (result != null)
            {
                result.TransactionId = transaction.TransactionId;
                result.TransactionDate = transaction.TransactionDate;
                if (transaction.TransactionId != 0)
                {
                    result.TransactionId = transaction.TransactionId;

                }
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
