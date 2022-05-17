using System;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Device.Location;

namespace Social_Drink
{

    [JsonObject(MemberSerialization.OptIn)]
    public class Search
    {
       
       // public string position { get; set; }

        [JsonProperty]
        public string house { get; set; }


        [JsonProperty]
        public string street { get; set; }

        [JsonProperty]
        public string postalCode { get; set; }

        [JsonProperty]
        public string district { get; set; }



        [JsonProperty]
        public string city { get; set; }

        [JsonProperty]
        public string stateCode { get; set; }


        [JsonProperty]
        public string county { get; set; }


        [JsonProperty]
        public string countryCode { get; set; }

        [JsonProperty]
        public string country { get; set; }


        [JsonProperty]
        public string text { get; set; }

    }

    [JsonObject(MemberSerialization.OptIn)]
    public class Address
    {

        [JsonProperty]
        public string house { get; set; }


        [JsonProperty]
        public string street { get; set; }

        [JsonProperty]
        public string postalCode { get; set; }

        [JsonProperty]
        public string district { get; set; }



        [JsonProperty]
        public string city { get; set; }

        [JsonProperty]
        public string stateCode { get; set; }


        [JsonProperty]
        public string county { get; set; }


        [JsonProperty]
        public string countryCode { get; set; }

        [JsonProperty]
        public string country { get; set; }


        [JsonProperty]
        public string text { get; set; }


    }





    [JsonObject(MemberSerialization.OptIn)]
    public class Place
    {

        [JsonProperty]
        public int distance { get; set; }

        [JsonProperty]
        public string title { get; set; }

        [JsonProperty]
        public double averageRating { get; set; }

        [JsonProperty]
        public string icon { get; set; }

        [JsonProperty]
        public string vicinity { get; set; }

        [JsonProperty]
        public string type { get; set; }

        [JsonProperty]
        public string href { get; set; }

        [JsonProperty]
        public string id { get; set; }

        public GeoCoordinate position { get; set; }

        [JsonProperty]
        public Category category { get; set; }

    }

    [JsonObject(MemberSerialization.OptIn)]
    public class Category
    {
        [JsonProperty]
        public string id { get; set; }

        [JsonProperty]
        public string title { get; set; }

        [JsonProperty]
        public string href { get; set; }

        [JsonProperty]
        public string type { get; set; }
    }


}
