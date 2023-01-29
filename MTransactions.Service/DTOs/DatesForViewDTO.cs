using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MTransactions.Service.DTOs
{
    [XmlRoot("Dates")]
    public class DatesForViewDTO
    {
        [XmlAttribute("Date")]
        public string Date { get; set; }
    }
}
