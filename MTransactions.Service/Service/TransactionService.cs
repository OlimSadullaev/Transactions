using MTransactions.Service.Constants;
using MTransactions.Service.DTOs;
using MTransactions.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace MTransactions.Service.Service
{
    public class TransactionService : ITransactionService
    {

        public async ValueTask<Response<DailyEXratesForViewDTO>> GetAllAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(ApiConstant.BASE_URL + DateTime.Now.ToString("MM.dd.yyyy"));

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

        public async ValueTask<Response<DailyEXratesForViewDTO>> GetAsync(DatesForViewDTO datesForViewDTO)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(ApiConstant.BASE_URL + datesForViewDTO);
                if (!response.IsSuccessStatusCode)
                {
                    return new Response<DailyEXratesForViewDTO>()
                    {
                        Message = await response.Content.ReadAsStringAsync(),
                        StatusCode = (int)response.StatusCode,
                    };
                    XmlSerializer serializer = new XmlSerializer(typeof(DailyEXratesForViewDTO));
                }
                var resp = new Response<DailyEXratesForViewDTO>();
                resp.StatusCode = (int)response.StatusCode;
                var res = await response.Content.ReadAsStringAsync();
                /*using (TextReader reader = new StringReader(res))
                {
                    resp.Value = (DailyEXratesForViewDTO)serializer.Deserializer(reader);
                }*/

                return resp;

                
            }
        }
    }
}
