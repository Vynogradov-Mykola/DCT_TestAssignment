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
   
    public partial class ListPage : Page
    {
        public ListPage()
        {
            InitializeComponent();
            TopList.Items.Add("sssssssssss");
            TopList.Items.Add("sssssssssssddd");
            TopList.Items.Add("sssssssssssfff");
            TopList.Items.Add("sssssssssssgggg");
            TopList.Items.Add("sssssssssssaaaa");
        }
        
  
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TopList.Items.Add("sssssssssssaaaa");
        }
    }
}
