using System.Windows.Controls;
using DCT_TestApp.ViewModels;
namespace DCT_TestApp
{
    public partial class Convert : Page
    {
        private ConvertCurrency _viewModel;
        public Convert(string Local)
        {
            InitializeComponent();
            _viewModel = new ConvertCurrency(Local);
            DataContext = _viewModel;
        }
  
    }
}
