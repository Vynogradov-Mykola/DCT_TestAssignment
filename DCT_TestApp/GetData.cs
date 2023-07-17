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
            using (HttpClient client = new HttpClient())
            {

                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = response.Content.ReadAsStringAsync().Result;
                    if (url == "https://api.coincap.io/v2/assets?limit=10")
                    {
                        //    Console.WriteLine(jsonResponse);
                        AssetResponse assetResponse = JsonConvert.DeserializeObject<AssetResponse>(jsonResponse);
                        return assetResponse.Data;
                    }
                    else if (url.Contains("https://api.coincap.io/v2/assets/"))
                    {
                        jsonResponse = jsonResponse.Insert(8, "[");
                        jsonResponse = jsonResponse.Insert(jsonResponse.IndexOf("timestamp") - 2, "]");
                        Console.WriteLine(jsonResponse);
                        AssetResponse assetResponse = JsonConvert.DeserializeObject<AssetResponse>(jsonResponse);
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
        } 
        public List<Market> GetMarkets(string url)
            {
                using (HttpClient client = new HttpClient())
                {

                    HttpResponseMessage response = client.GetAsync(url).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;

                        //    Console.WriteLine(jsonResponse);
                        MarketResponse marketResponse = JsonConvert.DeserializeObject<MarketResponse>(jsonResponse);
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
        }

    
    
    public class Asset
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal VolumeUsd24Hr { get; set; }
        public decimal ChangePercent24Hr { get; set; }
        public decimal PriceUsd { get; set; }
        // Add other properties as needed
    }
    public class Market
    {
        public string ExchangeId { get; set; }
        public decimal PriceUsd { get; set; }
    }


