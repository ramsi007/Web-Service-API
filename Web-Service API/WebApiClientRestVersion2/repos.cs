using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json.Serialization;

namespace WebApiClientRestVersion2
{
    public class Repository
    {
        // proreties
        [JsonPropertyName("name")]
        public string  Name { get; set; }
        [JsonPropertyName("id")]
        public int ?  Id { get; set; }
        [JsonPropertyName("description")]
        public string  Description { get; set;}
        [JsonPropertyName("homepage")]
        public Uri  HomePage { get; set;}
        [JsonPropertyName("watchers")]
        public int ? Watchers { get; set; }
        [JsonPropertyName("fork")]
        public bool ? IsFork { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime CreationDate { get; set; }
        [JsonPropertyName("pushed_at")]
        public DateTime PushedAt { get; set; }

        //Objets

        [JsonPropertyName("owner")]
        public Owner Owner { get; set; }
        [JsonPropertyName("license")]
        public Licence Licence { get; set; }
        [JsonPropertyName("permissions")]
        public Permission Permission { get; set; }

        public override string ToString()
        {
            return "Name : " + Name + "  Id : " + Id + "\n"+ "Description : " + Description +"\n"+
                    "CreationDate : " + CreationDate + "\n" + "PushedAt : " + PushedAt + "\n" +
                   "HomePage  :" + HomePage +" Watchers :" + Watchers + " Fork  :" + IsFork
                   + "\n" + " || " + Owner + "\n" + " || " + Licence + "\n" + " || " + Permission;
        }
    }

    public class Owner
    {
        [JsonPropertyName("id")]
        public int Id { get; set;}

        [JsonPropertyName("login")]
        public string Login { get; set; }

        public override string ToString()
        {
            return "[Owner Id: " + Id + "  Login :" + Login + "]";
        }
    }

    public class Licence
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        public override string ToString()
        {
            return "[Licence Key: " + Key + "  Name :" + Name + " URL : "+ Url +"]";
        }

    }

    public class Permission
    {
        [JsonPropertyName("amin")]
        public string Admin { get; set; }

        [JsonPropertyName("push")]
        public bool IsPush { get; set; }

        [JsonPropertyName("pull")]
        public bool IsPull { get; set; }

        public override string ToString()
        {
            return "[Licence Admin: " + Admin + "  Push :" + IsPush + " Pull : " + IsPull + "]";
        }
    }
}
