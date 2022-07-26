using Newtonsoft.Json;
using System.Net;

namespace DeckOfCardsAPILab.Models
{
    public class DeckDAL
    {
        public DeckModel DrawCards() //adjust
        {
            //adjust
            //api url
            string key = "vgln20rp1mwn";
            string url = $"https://deckofcardsapi.com/api/deck/{key}/draw/?count=5";
            //setup request
            HttpWebRequest request = WebRequest.CreateHttp(url);
            //capture response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //save response data
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();
            //adjust
            //convert JSON into C# object
            DeckModel result = JsonConvert.DeserializeObject<DeckModel>(JSON);
            return result;
        }
        public void ShuffleCards()
        {
            string key = "vgln20rp1mwn";
            string url = $"https://deckofcardsapi.com/api/deck/{key}/shuffle/";

            HttpWebRequest request = WebRequest.CreateHttp(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        }
    }
}

