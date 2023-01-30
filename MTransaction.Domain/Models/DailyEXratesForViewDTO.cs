using System.Xml.Serialization;

namespace MTransaction.Domain.Models
{
    [XmlRoot("DailyExRates")]
    public class DailyEXratesForViewDTO
    {
        [XmlAttribute("Date")]
        public string Date { get; set; }

        [XmlElement("Currency")]
        public TransactionForViewDTO[] Currency { get; set; }
    }
}
