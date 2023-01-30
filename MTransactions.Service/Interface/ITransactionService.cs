using MTransaction.Domain.Models;

namespace MTransactions.Service.Interface
{
    public interface ITransactionService
    {
        ValueTask<Response<DailyEXratesForViewDTO>> GetAllAsync(string Date);
    }
}