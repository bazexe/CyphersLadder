using MyValorantStore.MVVM.Model;
using System;
using RestSharp;
using ValNet;
using ValNet.Objects.Authentication;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Authenticators.OAuth2;
using Newtonsoft.Json;

namespace MyValorantStore.MVVM.ViewModel
{
    internal class MainViewModel
    {
        public ObservableCollection<Player> Players { get; set; }

        public MainViewModel()
        {
            Players = new ObservableCollection<Player>();
            PopulateCollection();
        }

        void PopulateCollection()
        {
            var client = new RestClient();
            
            /*client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator("RGAPI-11caeb2c-9a1b-4614-92ec-5911e0cd522c", "Bearer");*/
            

            var request = new RestRequest("https://na.api.riotgames.com/val/ranked/v1/leaderboards/by-act/d929bc38-4ab6-7da4-94f0-ee84f8ac141e?size=50&startIndex=0&api_key=RGAPI-11caeb2c-9a1b-4614-92ec-5911e0cd522c", Method.Get);
            request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:99.0) Gecko/20100101 Firefox/99.0");
            request.AddHeader("Accept-Language", "en-US,en;q=0.5");
            request.AddHeader("Accept-Charset", "application/x-www-form-urlencoded; charset=UTF-8");
            request.AddHeader("Origin", "https://developer.riotgames.com");

            var response = client.GetAsync(request).GetAwaiter().GetResult();
            var data = JsonConvert.DeserializeObject<RanksModel>(response.Content);

            for (int i = 0; i<data.Players.Length; i++)
            {
                var player = data.Players[i];
                player.RankedRating = data.Players[i].RankedRating;
                Players.Add(player);
            }
        }
    }
}
