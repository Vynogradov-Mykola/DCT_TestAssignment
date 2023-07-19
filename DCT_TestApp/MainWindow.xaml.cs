using System;
using System.Windows;
using System.Windows.Media;

namespace DCT_TestApp
{
   
    public partial class MainWindow : Window
    {
        public string Local = "EN";
        
        
        bool DarkTheme = false;
        
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new ListPage(Local));
            // Load and apply the light theme
            ResourceDictionary LightTheme = new ResourceDictionary();
            LightTheme.Source = new Uri("LightTheme.xaml", UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Add(LightTheme);
            DarkTheme = false;
            
        }
        
        private void ListPage_Click(object sender, RoutedEventArgs e)
        {
            ListPage listpage = new ListPage(Local);
            MainFrame.Navigate(listpage);   //navigate to ListPage
        }
        private void DetailedInfPage_Click(object sender, RoutedEventArgs e)
        {
            DetailedInfPage detailedinfpage = new DetailedInfPage(Local);
            MainFrame.Navigate(detailedinfpage);//navigate to DetailedInfPage
        }
        private void ConvertPage_Click(object sender, RoutedEventArgs e)
        {
            Convert convert = new Convert(Local);
            MainFrame.Navigate(convert); //navigate to ConverPage
        }
       
        private void Button_Click(object sender, RoutedEventArgs e) //change theme
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
                // Load and apply the light theme
                ResourceDictionary LightTheme = new ResourceDictionary();
                LightTheme.Source = new Uri("LightTheme.xaml", UriKind.Relative);
                Application.Current.Resources.MergedDictionaries.Add(LightTheme);
                DarkTheme = false;
                Background = Brushes.White;
            }
            
        }
        private void Local_Click(object sender, RoutedEventArgs e) //change theme
        {
            if (Local=="UA")
            {
                LocalButton.Content = "En";
                Local = "EN";
            }
            else if(Local=="EN")
            {
                LocalButton.Content = "Ua";
                Local = "UA";
            }
            

        }
    }
}
