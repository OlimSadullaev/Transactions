using MTransaction.Domain.Models;
using MTransactions.UI.Private;
using System.Windows.Controls;

namespace MTransactions.UI.Pages
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();
        }

        public DailyEXratesForViewDTO EXrates { get; set; }

        private async void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            foreach(var item in EXrates?.Currency)
            {
                await this.Dispatcher.InvokeAsync(() => 
                {
                    CurrencySetting currencySettings = new CurrencySetting();
                    currencySettings.CharCode.Text = item.CharCode;
                    currencySettings.Scale_Name.Text = item.Name;
                    TransactionList.Items.Add(currencySettings);
                });
            }
        }
    }
}
