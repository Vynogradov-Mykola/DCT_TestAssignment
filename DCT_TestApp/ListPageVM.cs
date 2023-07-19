using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace DCT_TestApp.ViewModels
{
    public class ListPageVM : INotifyPropertyChanged
    {
        private string _id;
        private decimal _price;
        private ObservableCollection<string> _topList;
        private ICommand _searchCommand;
        private Asset _selectedCurrency;
        public List<Asset> assets = new List<Asset>();

        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public Asset SelectedCurrency
        {
            get { return _selectedCurrency; }
            set
            {
                _selectedCurrency = value;
                OnPropertyChanged(nameof(SelectedCurrency));
            }
        }

        public ObservableCollection<string> TopList
        {
            get { return _topList; }
            set
            {
                _topList = value;
                OnPropertyChanged(nameof(TopList));
            }
        }


        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        public string currloc;
        public string priceloc;
        public ListPageVM(string Local)
        {
            if(Local=="EN")
            {
                currloc = "Currency: ";
                priceloc = "Price: ";
            }
            else if(Local=="UA")
            {
                currloc = "Валюта: ";
                priceloc = "Ціна: ";
            }
            Search(""); //on create, start search for top 10 currencies
        }
        public ListPageVM()
        {
           
        }
        public ICommand SearchCommand => _searchCommand ?? (_searchCommand = new RelayCommand(Search)); //comand for search
        public void Search(object parameter)
        {
                   GetData get = new GetData();
                   assets = new List<Asset>();
                   string url = "https://api.coincap.io/v2/assets?limit=10";    //url for top 10 currencies
                   assets = get.GetAssets(url);
                   if (assets != null)
                   {
                   TopList = new ObservableCollection<string>(); // Initialize the TopList property
                   foreach (Asset asset in assets)
                         {
                             string adder =($"{currloc} {asset.Name}, {priceloc} {asset.PriceUsd} USD");
                             TopList.Add(adder);
                         }
                   }
        }
       
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
