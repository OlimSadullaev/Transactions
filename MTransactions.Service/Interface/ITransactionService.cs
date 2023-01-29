using MTransactions.Service.DTOs;

namespace MTransactions.Service.Interface
{
    public interface ITransactionService
    {
        ValueTask<Response<DailyEXratesForViewDTO>> GetAllAsync();
        ValueTask<Response<DailyEXratesForViewDTO>> GetAsync(DatesForViewDTO datesForViewDTO);
    }
}