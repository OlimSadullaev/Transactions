using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTransactions.Service.DTOs
{
    public class TransactionSettingsForViewDTO
    {
        public string CharCode { get; set; }

        public int Scale { get; set; }

        public string Name { get; set; }
    }
}
