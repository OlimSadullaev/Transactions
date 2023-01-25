using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTransactions.Service.DTOs
{
    public class TransactionForViewDTO
    {
        public int NumCode { get; set; }

        public string CharCode { get; set; }

        public int Scale { get; set; }

        public string Name { get; set; }

        public double Rate { get; set; }

    }
}
