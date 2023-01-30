using MTransaction.Domain.Models;
using MTransactions.Service.Constants;
using MTransactions.Service.Interface;
using System.Xml.Serialization;

namespace MTransactions.Service.Service
{
    public class TransactionService : ITransactionService
    {

        public async ValueTask<Response<DailyEXratesForViewDTO>> GetAllAsync(string Date)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(ApiConstant.BASE_URL + Date);

                if (!response.IsSuccessStatusCode)
                {
                    return new Response<DailyEXratesForViewDTO>()
                    {
                        Message = await response.Content.ReadAsStringAsync(),
                        StatusCode = (int)response.StatusCode,
                    };
                }
                XmlSerializer serializer = new XmlSerializer(typeof(DailyEXratesForViewDTO));

                var resp = new Response<DailyEXratesForViewDTO>();
                resp.StatusCode = (int)response.StatusCode;
                var res = await response.Content.ReadAsStringAsync();
                using (TextReader reader = new StringReader(res))
                {
                    resp.Value = (DailyEXratesForViewDTO)serializer.Deserialize(reader);
                }

                return resp;
            }
        }
    }
}
