using System.Windows.Controls;
namespace DCT_TestApp
{

    public partial class ChartPage : Page
    {
        
        public ChartPage(string currency)
        {
            InitializeComponent();
            DataContext = new QuoteChartGetData(currency);  //create quote chart
        }
       
    }
}
