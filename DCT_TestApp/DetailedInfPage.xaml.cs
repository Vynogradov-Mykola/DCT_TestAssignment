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
            Name.Text = Currency;
            GetData a = new GetData();
            List<Asset> assets = new List<Asset>();
            string url = "https://api.coincap.io/v2/assets/"+Currency.ToLower();
            assets = a.GetAssets(url);

            if (assets != null)
            {
                foreach (Asset asset in assets)
                {
                    Name.Text = asset.Name;
                    Volume.Text = asset.VolumeUsd24Hr.ToString();
                    Price.Text = asset.PriceUsd.ToString();
                    PriceChange.Text = asset.ChangePercent24Hr.ToString();
                    ID.Text = asset.Id.ToString();
                }
            }
            List<Market> markets = new List<Market>();
            url = "https://api.coincap.io/v2/assets/" + Currency.ToLower()+"/markets?limit=10";
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
