using MTransactions.Service.DTOs;
using MTransactions.Service.Interface;
using MTransactions.Service.Service;
using MTransactions.UI.Private;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MTransactions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DailyEXratesForViewDTO dailyEXrates;
        private readonly ITransactionService transactionService;
        public MainWindow()
        {
            transactionService = new TransactionService();
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TransactionList.Items.Clear();
            dailyEXrates = (await transactionService.GetAllAsync()).Value;
            await LoadTransactions();
        }
        private async ValueTask LoadTransactions()
        {
            foreach (var i in dailyEXrates.Currency)
            {
                await this.Dispatcher.InvokeAsync(() =>
                {
                    Currency currency = new Currency();
                    currency.CharCode.Text = i.CharCode;
                    currency.Scale_Name.Text = i.Scale + " " + i.Name;
                    currency.FirstRate.Text = i.Rate.ToString();
                    currency.SecondRate.Text = i.Rate.ToString();
                    TransactionList.Items.Add(currency);
                });
            }
        }
    }
}
