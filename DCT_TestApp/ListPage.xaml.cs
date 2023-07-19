using DCT_TestApp.ViewModels;
using System.Windows.Controls;


namespace DCT_TestApp
{
   
    public partial class ListPage : Page
    {
        private ListPageVM _viewModel;
        private string Loc;
        public ListPage(string Local)
        {
            Loc = Local;
            InitializeComponent();
            _viewModel = new ListPageVM(Local);
            DataContext = _viewModel;
        }
        
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationService.Navigate(new DetailedInfPage(_viewModel.assets[TopList.SelectedIndex].Id,Loc));       //Go to DetailedInfPage with selected currency
        }
    }
}
