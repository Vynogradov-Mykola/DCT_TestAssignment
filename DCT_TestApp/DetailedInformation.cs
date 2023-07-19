using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace DCT_TestApp.ViewModels
{
    public class DetailedInfViewModel : INotifyPropertyChanged
    {
        private string _id;
        private string _name;
        private string _volume;
        private string _price;
        private string _priceChange;
        private string _infloc;
        private string _markloc;
        private string _searchbtnloc;
        private string _dispchartsloc;
        private ObservableCollection<string> _marketList;
        private ICommand _searchCommand;
        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public string MarkLoc
        {
            get { return _markloc; }
            set
            {
                _markloc = value;
                OnPropertyChanged(nameof(MarkLoc));
            }
        }
        public string InfLoc
        {
            get { return _infloc; }
            set
            {
                _infloc = value;
                OnPropertyChanged(nameof(InfLoc));
            }
        }
        public string SearchLoc
        {
            get { return _searchbtnloc; }
            set
            {
                _searchbtnloc = value;
                OnPropertyChanged(nameof(SearchLoc));
            }
        }
        public string DispChartLoc
        {
            get { return _dispchartsloc; }
            set
            {
                _dispchartsloc = value;
                OnPropertyChanged(nameof(DispChartLoc));
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Volume
        {
            get { return _volume; }
            set
            {
                _volume = value;
                OnPropertyChanged(nameof(Volume));
            }
        }
        public string Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        public string PriceChange
        {
            get { return _priceChange; }
            set
            {
                _priceChange = value;
                OnPropertyChanged(nameof(PriceChange));
            }
        }
        public ObservableCollection<string> MarketList
        {
            get { return _marketList; }
            set
            {
                _marketList = value;
                OnPropertyChanged(nameof(MarketList));
            }
        }
        public string nameloc;
        public string priceloc;
        public string price24loc;
        public string volumeloc;
        public string marketloc;

        public DetailedInfViewModel()
        {
        }
        public DetailedInfViewModel(string Local)
        {
            if (Local == "EN")
            {
                nameloc = "Currency: ";
                priceloc = "Price: ";
                price24loc = "Change price last 24Hr: ";
                volumeloc = "Volume: ";
                marketloc = "Market: ";
                MarkLoc = "Markets";
                InfLoc = "Information:";
                SearchLoc = "Search";
                DispChartLoc = "Display quote charts";
            }
            else if (Local == "UA")
            {
                nameloc = "Валюта: ";
                priceloc = "Цiна: ";
                price24loc = "Змiна цiни за останнi 24 години: ";
                volumeloc = "Обсяг: ";
                marketloc = "Ринок: ";
                MarkLoc = "Ринки";
                InfLoc = "Інформація:";
                SearchLoc = "Пошук";
                DispChartLoc = "Відобразити графік змін валюти";
            }
        }
        public ICommand SearchCommand => _searchCommand ?? (_searchCommand = new RelayCommand(Search)); //comand for search
        public void Search(object parameter)    //search for currency
        {
           
            string id = parameter as string;
            if (!string.IsNullOrEmpty(id))
            {
                GetData a = new GetData();
                string url = "https://api.coincap.io/v2/assets/" + id.ToLower();    //for currency information
                List<Asset> assets = a.GetAssets(url);
                if (assets != null && assets.Count > 0)
                {
                    Id = assets[0].Id;
                    Name = nameloc + assets[0].Name;
                    Volume = volumeloc + assets[0].VolumeUsd24Hr.ToString();
                    Price = priceloc + assets[0].PriceUsd;
                    PriceChange = price24loc + assets[0].ChangePercent24Hr;
                }

                List<Market> markets = new List<Market>();
                url = "https://api.coincap.io/v2/assets/" + id.ToLower() + "/markets?limit";    //for markets with currency
                markets = a.GetMarkets(url);
                if (markets != null)
                {
                    MarketList = new ObservableCollection<string>();
                    foreach (Market market in markets)
                    {
                        string adder = $"{marketloc} {market.ExchangeId}, {priceloc} {market.PriceUsd} USD";
                        MarketList.Add(adder);
                    }
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
