using System.Collections.Generic;
using System.Windows.Controls;


namespace DCT_TestApp
{
   
    public partial class ListPage : Page
    {
        GetData a = new GetData();
        List<Asset> assets = new List<Asset>();
        public ListPage()
        {
            InitializeComponent();
            
            string url = "https://api.coincap.io/v2/assets?limit=10";
            assets = a.GetAssets(url);

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
            NavigationService.Navigate(new DetailedInfPage(assets[TopList.SelectedIndex].Name));
        }
    }
}
