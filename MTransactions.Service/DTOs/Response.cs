using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTransactions.Service.DTOs
{
    public class Response<T> where T : class
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Value { get; set; }
    }
}
