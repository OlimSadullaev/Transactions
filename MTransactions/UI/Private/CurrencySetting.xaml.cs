using MTransaction.Domain.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.IO;
using System.Linq;
using System.Windows.Controls;

namespace MTransactions.UI.Private
{
    /// <summary>
    /// Interaction logic for CurrencySetting.xaml
    /// </summary>
    public partial class CurrencySetting : UserControl
    {
        public CurrencySetting()
        {
            InitializeComponent();
        }

        private void ToggleButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            EXRateJson eXRateJson = new EXRateJson();
            if (!Directory.Exists("AppSettings"))
                Directory.CreateDirectory("AppSettings");

            if (!File.Exists("AppSettings/appSettings.json") ||
                string.IsNullOrEmpty(File.ReadAllText("AppSettings/appsettings.json")))
                File.WriteAllText("AppSettings/appsettings.json", "[]");

            var exRates = JsonConvert.DeserializeObject<List<EXRateJson>>(File.ReadAllText("AppSettings/appsettings.json"));

            var existEXRate = exRates.FirstOrDefault(e => e.CharCode == CharCode.Text);
            if (existEXRate != null)
                {
                exRates.Remove(existEXRate);
                existEXRate.IsChecked = (bool)showoff.IsChecked;
                exRates.Add(existEXRate);
            }
            else
            {

                EXRateJson exRate = new EXRateJson()
                {
                    CharCode = CharCode.Text,
                    ScaleName = Scale_Name.Text,
                    IsChecked = (bool)showoff.IsChecked
                };
                exRates.Add(exRate);
            }
            File.WriteAllText("AppSettings/appsettings.json", JsonConvert.SerializeObject(exRates));
        }
    }
}
