using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json; // for JSON
namespace DCT_TestApp
{
    public class AssetResponse
    {
        public List<Asset> Data { get; set; }
    }
    public class MarketResponse
    {
        public List<Market> Data { get; set; }
    }
    class GetData
    {
        public List<Asset> GetAssets(string url)
        {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = response.Content.ReadAsStringAsync().Result;  //response string
                    if (url == "https://api.coincap.io/v2/assets?limit=10") //request for top 10 currencies
                    {
                        AssetResponse assetResponse = JsonConvert.DeserializeObject<AssetResponse>(jsonResponse);   //convert
                        return assetResponse.Data;
                    }
                    else if (url.Contains("https://api.coincap.io/v2/assets/"))     //request for search currency
                    {
                        jsonResponse = jsonResponse.Insert(8, "[");       //the response hasn`t two symbols. Add them to read like JSON
                        jsonResponse = jsonResponse.Insert(jsonResponse.IndexOf("timestamp") - 2, "]");
                        AssetResponse assetResponse = JsonConvert.DeserializeObject<AssetResponse>(jsonResponse);   //convert
                        return assetResponse.Data;
                    }
                    return null;
                }
                else
                {
                    Console.WriteLine("Failed to retrieve data. Status code: " + response.StatusCode);
                    return null;
                }
         
        } 
        public List<Market> GetMarkets(string url)  //request for market list of currency
            {
                 HttpClient client = new HttpClient();
                 HttpResponseMessage response = client.GetAsync(url).Result;
                 if (response.IsSuccessStatusCode)
                 {
                      string jsonResponse = response.Content.ReadAsStringAsync().Result;    //response string
                      MarketResponse marketResponse = JsonConvert.DeserializeObject<MarketResponse>(jsonResponse);  //convert
                      return marketResponse.Data;
                 }
                 else
                 {
                      Console.WriteLine("Failed to retrieve data. Status code: " + response.StatusCode);
                      return null;
                 }
            }
            }
        }
    
    public class Asset
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal VolumeUsd24Hr { get; set; }
        public decimal ChangePercent24Hr { get; set; }
        public decimal PriceUsd { get; set; }
    }
    public class Market
    {
        public string ExchangeId { get; set; }
        public decimal PriceUsd { get; set; }
    }


