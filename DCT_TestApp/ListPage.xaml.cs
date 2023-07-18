using System.Collections.Generic;
using System.Windows.Controls;


namespace DCT_TestApp
{
   
    public partial class ListPage : Page
    {
        GetData get = new GetData();
        List<Asset> assets = new List<Asset>();
        int N = 10;     //Default value for limit in search for top 10 currency
        public ListPage()
        {
            InitializeComponent();
            string url = "https://api.coincap.io/v2/assets?limit="+N.ToString();
            assets = get.GetAssets(url);
            if (assets != null)
            {
                foreach (Asset asset in assets)
                {
                    string adder =($"Currency: {asset.Name}, Price: {asset.PriceUsd} USD");
                    TopList.Items.Add(adder);
                }
            }
        }
        
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationService.Navigate(new DetailedInfPage(assets[TopList.SelectedIndex].Id));
        }
    }
}
