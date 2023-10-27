using RestaurantWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebAPI.Repository
{
    public interface ITransactionDetailsRepository
    {
        Task<IEnumerable<TransactionDetail>> GetTransactionDetails();
        Task<TransactionDetail> AddTransactionDetail(TransactionDetail transactionDetail);
        Task<TransactionDetail> UpdateTransactionDetail(TransactionDetail transactionDetail);
        Task DeleteTransactionDetail(int TransactionDetailId);
    }
}
