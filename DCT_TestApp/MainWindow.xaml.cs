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
   
    public partial class MainWindow : Window
    {
        ListPage listpage = new ListPage();
        DetailedInfPage detailedinfpage = new DetailedInfPage();
        Convert convert = new Convert();
        bool DarkTheme = false;
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new ListPage());
            // Load and apply the light theme
            ResourceDictionary LightTheme = new ResourceDictionary();
            LightTheme.Source = new Uri("LightTheme.xaml", UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Add(LightTheme);
            DarkTheme = false;
            
        }
        
        private void ListPage_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(listpage);
        }
        private void DetailedInfPage_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(detailedinfpage);
        }
        private void ConvertPage_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(convert);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DarkTheme == false)
            {
                // Load and apply the dark theme
                ResourceDictionary darkTheme = new ResourceDictionary();
                darkTheme.Source = new Uri("DarkTheme.xaml", UriKind.Relative);
                Application.Current.Resources.MergedDictionaries.Add(darkTheme);
                DarkTheme = true;
                Background = Brushes.DarkSlateGray;
            }
            else
            {
                // Remove the dark theme
                ResourceDictionary darkTheme = new ResourceDictionary();
                darkTheme.Source = new Uri("DarkTheme.xaml", UriKind.Relative);
                Application.Current.Resources.MergedDictionaries.Remove(darkTheme);
                // Load and apply the light theme
                ResourceDictionary LightTheme = new ResourceDictionary();
                LightTheme.Source = new Uri("LightTheme.xaml", UriKind.Relative);
                Application.Current.Resources.MergedDictionaries.Add(LightTheme);
                DarkTheme = false;
                Background = Brushes.White;
            }
            
        }
    }
}
