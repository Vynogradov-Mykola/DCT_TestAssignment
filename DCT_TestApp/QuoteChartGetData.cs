using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Newtonsoft.Json;
using System.Net.Http;
using System;

namespace DCT_TestApp
{
    class QuoteChartGetData : DependencyObject
    {
        public SeriesCollection QuoteSeries
        {
            get { return (SeriesCollection)GetValue(QuoteSeriesProperty); }
            set { SetValue(QuoteSeriesProperty, value); }
        }

        public static readonly DependencyProperty QuoteSeriesProperty =
            DependencyProperty.Register("QuoteSeries", typeof(SeriesCollection), typeof(QuoteChartGetData), new PropertyMetadata(null));

        public Func<double, string> XLabelFormatter { get; set; }

        public QuoteChartGetData(string currency)
        {
            LoadQuoteData(currency);
        }

        private async void LoadQuoteData(string currency)   //load quote charts information
        {
            
            string url = $"https://api.coincap.io/v2/assets/{currency}/history?interval=d1";    //url to API

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    CoinCapResponse coinCapResponse = JsonConvert.DeserializeObject<CoinCapResponse>(jsonResponse);

                    List<DateTimePoint> dataPoints = coinCapResponse.Data.Select(q => new DateTimePoint(new DateTime(q.Time * 1000), q.PriceUsd)).ToList();

                    var lineSeries = new LineSeries
                    {
                        Title = currency,
                        Values = new ChartValues<DateTimePoint>(dataPoints),
                        Fill = Brushes.Transparent
                    };

                    QuoteSeries = new SeriesCollection { lineSeries };
                    XLabelFormatter = value => new DateTime((long)value).ToString("dd MMM");    //label for date
                }
            }
        }
    }

    public class CoinCapQuote   //class for coin cap information
    {
        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("priceUsd")]
        public double PriceUsd { get; set; }
    }

    public class CoinCapResponse
    {
        [JsonProperty("data")]
        public List<CoinCapQuote> Data { get; set; }
    }
}

