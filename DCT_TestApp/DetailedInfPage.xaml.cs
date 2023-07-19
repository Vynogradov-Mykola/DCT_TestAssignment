using DCT_TestApp.ViewModels;
using System.Windows.Controls;
namespace DCT_TestApp
{
    public partial class DetailedInfPage : Page
    {
        private DetailedInfViewModel _viewModel;

        public DetailedInfPage()
        {
            InitializeComponent();
            _viewModel = new DetailedInfViewModel();
            DataContext = _viewModel;
        }

        public DetailedInfPage(string currency, string local) : this()
        {
            InitializeComponent();
            _viewModel = new DetailedInfViewModel(local);
            DataContext = _viewModel;
            _viewModel.Search(currency);    //search for currency
        }
        public DetailedInfPage(string local) : this()
        {
            InitializeComponent();
            _viewModel = new DetailedInfViewModel(local);
            DataContext = _viewModel;
        }
        private void DisplayChartsButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChartPage(ID.Text));//navigate to ChartPage with ID
        }
        
    }
}
