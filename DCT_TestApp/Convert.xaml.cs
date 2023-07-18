using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DCT_TestApp
{
    public partial class Convert : Page
    {
        public Convert()
        {
            InitializeComponent();
        }
        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            string firstCurrency = FirstCurrency.Text;
            string secondCurrency = SecondCurrency.Text;
            decimal price = 0;
            GetData get = new GetData();
            List<Asset> assets = new List<Asset>();
            string url = "https://api.coincap.io/v2/assets/" + firstCurrency.ToLower();
            assets = get.GetAssets(url);
            if (assets != null)
            {
                price = assets[0].PriceUsd;
            }
            url = "https://api.coincap.io/v2/assets/" + secondCurrency.ToLower();
            assets = get.GetAssets(url);
            if (assets != null)
            {
                int count = 0;
                Int32.TryParse(CountFirst.Text, out count);
                decimal convertCount = (count*price) / assets[0].PriceUsd;
                CountSecond.Text = convertCount.ToString();
            }
        }
    }
}
