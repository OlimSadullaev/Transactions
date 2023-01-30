using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MTransaction.Domain.Models
{
    public class EXRateJson
    {
        public string CharCode { get; set; }

        public string ScaleName { get; set; }

        public bool IsChecked { get; set; }
    }
}
