//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Text;
//using System.Text.Json.Serialization;

//namespace WebApliClientRest
//{
//    public class Repository
//    {
//        [JsonPropertyName("name")]
//        public string Name { get; set; }

//        [JsonPropertyName("description")]
//        public string Description { get; set; }

//        [JsonPropertyName("html_url")]
//        public Uri GitHubHomeUrl { get; set; }

//        [JsonPropertyName("homepage")]
//        public Uri Homepage { get; set; }

//        [JsonPropertyName("watchers")]
//        public int Watchers { get; set; }

//        [JsonPropertyName("fork")]
//        public bool? Fork { get; set; }

//        [JsonPropertyName("license")]
//        public Licence Licence { get; set; }

//        //public override string ToString()
//        //{
//        //    return "[Repository : Id = " + Id + "Name = " + Name
//        //        + "Licence = " + Licence + "Owner = " + Owner + "Permissions = " + Permissions + "]";
//        //}


//        }

//        public class Licence
//    {
//        [JsonPropertyName("key")]
//        public string Key { get; set; }
//        [JsonPropertyName("name")]
//        public string Name { get; set; }

//        public Licence()
//        {

//        }

//        public Licence(string key, string name)
//        {
//            this.Key = key;
//            this.Name = name;
//        }

//        public override string ToString()
//        {
//            return "Key: " + this.Key + "Nom :" + this.Name;
//        }
//    }
//}
