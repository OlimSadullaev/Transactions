using MTransaction.Domain.Models;
using MTransactions.Service.Interface;
using MTransactions.Service.Service;
using MTransactions.UI.Pages;
using MTransactions.UI.Private;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

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
            DateForToday.Text = DateTime.Now.ToString("MM.dd.yyyy");
            DateForTomorrov.Text = (DateTime.Now - TimeSpan.FromDays(1)).ToString("MM.dd.yyyy");
        }


        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TransactionList.Items.Clear();
            dailyEXrates = (await transactionService.GetAllAsync(DateForToday.Text)).Value;
            await LoadTodaysTransactions();
            dailyEXrates = (await transactionService.GetAllAsync(DateForTomorrov.Text)).Value;
            await LoadTomorrovsTransactions();
        }
        private async ValueTask LoadTodaysTransactions()
        {
            foreach (var i in dailyEXrates.Currency)
            {
                await this.Dispatcher.InvokeAsync(() =>
                {
                    Currency currency = new Currency();
                    currency.CharCode.Text = i.CharCode;
                    currency.Scale_Name.Text = i.Scale + " " + i.Name;
                    currency.SecondRate.Text = i.Rate.ToString();
                    TransactionList.Items.Add(currency);
                });
            }
        }
        private async ValueTask LoadTomorrovsTransactions()
        {
            int index = 0;
            foreach (var i in TransactionList.Items)
            {
                await this.Dispatcher.InvokeAsync(() => 
                {
                    var currensy = i as Currency;
                    if (index == dailyEXrates.Currency.Length)
                        return;
                    currensy.FirstRate.Text = dailyEXrates.Currency.ElementAt(index).Rate.ToString();
                    index++;
                });
            }
        }

        private void Date_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            DateTime date;
            if (DateTime.TryParse(textBox.Text, out date))
                Window_Loaded(sender, e);
        }
        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            settings.EXrates = dailyEXrates;
            SettingsFrame.Content = settings;
        }
    }
}
