using System.Collections.Generic;
using System.Windows.Controls;
namespace DCT_TestApp
{
    public partial class DetailedInfPage : Page
    {
        public DetailedInfPage()
        {
            InitializeComponent();
        }
        public DetailedInfPage(string Currency)
        {
            InitializeComponent();
            SetInfo(Currency);
        }

        private void SearchButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SetInfo(ID.Text);
        }
        public void SetInfo(string id)      //get and set currency information
        {
            ID.Text = id;
            GetData a = new GetData();
            List<Asset> assets = new List<Asset>();
            string url = "https://api.coincap.io/v2/assets/" + id.ToLower();
            assets = a.GetAssets(url);
            if (assets != null)
            {
                    ID.Text = assets[0].Id;
                    Name.Text = "Name: " + assets[0].Name;
                    Volume.Text = "Volume: " + assets[0].VolumeUsd24Hr.ToString();
                    Price.Text = "Price: " + assets[0].PriceUsd.ToString();
                    PriceChange.Text = "Price change: " + assets[0].ChangePercent24Hr.ToString();
            }
            MarketList.Items.Clear();
            List<Market> markets = new List<Market>();
            url = "https://api.coincap.io/v2/assets/" + id.ToLower() + "/markets?limit";
            markets = a.GetMarkets(url);
            if (markets != null)
            {
                foreach (Market market in markets)
                {
                    string adder = ($"Market: {market.ExchangeId}, Price: {market.PriceUsd} USD");
                    MarketList.Items.Add(adder);
                }
            }
        }

    }
}
