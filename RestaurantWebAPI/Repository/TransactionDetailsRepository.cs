using Microsoft.EntityFrameworkCore;
using RestaurantWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebAPI.Repository
{
    public class TransactionDetailsRepository : ITransactionDetailsRepository
    {
        private readonly AppDbContext appDbContext;

        public TransactionDetailsRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<TransactionDetail> AddTransactionDetail(TransactionDetail transactionDetail)
        {
            var result = await appDbContext.TransactionDetails.AddAsync(transactionDetail);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteTransactionDetail(int transactionDetailId)
        {
            var result = await appDbContext.TransactionDetails.FirstOrDefaultAsync(e => e.TransactionDetailId == transactionDetailId);
            if (result != null)
            {
                appDbContext.TransactionDetails.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TransactionDetail>> GetTransactionDetails()
        {
            return await appDbContext.TransactionDetails.ToListAsync();
        }

        public async Task<TransactionDetail> UpdateTransactionDetail(TransactionDetail transactionDetail)
        {
            var result = await appDbContext.TransactionDetails.FirstOrDefaultAsync(e => e.TransactionDetailId == transactionDetail.TransactionDetailId);
            if (result != null)
            {
                result.TransactionId = transactionDetail.TransactionId;
                result.Quantity = transactionDetail.Quantity;
                result.FoodId = transactionDetail.FoodId;
                result.Subtotal = transactionDetail.Subtotal;
                if (transactionDetail.TransactionDetailId != 0)
                {
                    result.TransactionDetailId = transactionDetail.TransactionDetailId;

                }
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
