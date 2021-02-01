using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WebApliClientRest
{
    public class Repository
    {
        [JsonPropertyName("id")]
        public int ? Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("fork")]
        public bool ? Fork { get; set; }

        [JsonPropertyName("homepage")]
        public Uri HomePage { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreationDate { get; set; }

        [JsonPropertyName("pushed_at")]
        public DateTime PushedAt { get; set; }

        public DateTime LastPush => PushedAt.ToLocalTime();

        [JsonPropertyName("owner")]
        public Owner Owner { get; set; }

        [JsonPropertyName("license")]
        public Licence Licence { get; set; }

        [JsonPropertyName("permissions")]
        public Permission Permission { get; set; }

        public override string ToString()
        {
            return "[Repository : Id = " + Id + ", Name = " + Name
                + ", " + Owner
                + ", " + Licence
                + ", " + Permission + "]";
        }
    }

    public class Owner
    {
        [JsonPropertyName("login")]
        public string Login { get; set; }

        [JsonPropertyName("id")]
        public int ? Id { get; set; }

        public override string ToString()
        {
            return "[Owner : Login =" + Login + ", Id = " + Id + " ]";
        }
    }

    public class Licence
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        public override string ToString() {
            return "[Licence : Key =" + Key + ", Name = " + Name + " ]";
        }
    }

    public class Permission
    {
        [JsonPropertyName("admin")]
        public bool ? IsAdmin { get; set; }

        [JsonPropertyName("push")]
        public bool? IsPush { get; set; }

        [JsonPropertyName("pull")]
        public bool? IsPull { get; set; }

        public override string ToString()
        {
            return "[Permission : IsAdmin =" + IsAdmin + ", Push = " + IsPush +
            ", IsPull = " + IsPull + " ]";
        }
    }
}

