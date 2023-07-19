using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace DCT_TestApp.ViewModels
{
    class ConvertCurrency : INotifyPropertyChanged
    {
        private string _firstid;
        private string _secondid;
        private string _countfirst;
        private string _countsecond;
        private string _convloc;
        private string _countloc;
        private ICommand _convertCommand;
        public string ConvLoc
        {
            get { return _convloc; }
            set
            {
                _convloc = value;
                OnPropertyChanged(nameof(ConvLoc));
            }
        }
        public string CountLoc
        {
            get { return _countloc; }
            set
            {
                _countloc = value;
                OnPropertyChanged(nameof(CountLoc));
            }
        }
        public string FirstCurrency
        {
            get { return _firstid; }
            set
            {
                _firstid = value;
                OnPropertyChanged(nameof(FirstCurrency));
            }
        }
        public string SecondCurrency
        {
            get { return _secondid; }
            set
            {
                _secondid = value;
                OnPropertyChanged(nameof(SecondCurrency));
            }
        }
        public string CountFirst
        {
            get { return _countfirst; }
            set
            {
                _countfirst = value;
                OnPropertyChanged(nameof(CountFirst));
            }
        }
        public string CountSecond
        {
            get { return _countsecond; }
            set
            {
                _countsecond = value;
                OnPropertyChanged(nameof(CountSecond));
            }
        }
        public ConvertCurrency()
        {

        }
        public ConvertCurrency(string Local)
        {
            if (Local == "EN")
            {
                CountLoc = "Count:";
                ConvLoc = "Convert";
            }
            else if (Local == "UA")
            {
                CountLoc = "Кількість: ";
                ConvLoc = "Конвертувати";
            }
        }
        public ICommand ConvertCommand => _convertCommand ?? (_convertCommand = new RelayCommand(Convert)); //comand for search

        public void Convert(object parameter)
        {

            string id = parameter as string;
            string firstCurrency = FirstCurrency;
            string secondCurrency = SecondCurrency;
            decimal price = 0;
            GetData get = new GetData();
            List<Asset> assets = new List<Asset>();
            string url = "https://api.coincap.io/v2/assets/" + firstCurrency.ToLower();
            assets = get.GetAssets(url);
            if (assets != null)
            {
                price = assets[0].PriceUsd;
            }
            if (secondCurrency != null && FirstCurrency != null && CountFirst != null)
            {
                url = "https://api.coincap.io/v2/assets/" + SecondCurrency.ToLower();
                assets = get.GetAssets(url);
                if (assets != null)
                {
                    int count = 0;
                    Int32.TryParse(CountFirst, out count);
                    decimal convertCount = (count * price) / assets[0].PriceUsd;
                    CountSecond = convertCount.ToString();
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
