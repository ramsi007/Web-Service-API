using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;

namespace Web_Service_Meteo
{
    public class Meteo
    {
        [JsonPropertyName("request_state")]
        public int Request_State { get; set; }

        [JsonPropertyName("request_key")]
        public string Request_Key { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("model_run")]
        public string Model_Run { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }

        //string str = ;
        [JsonPropertyName("2020-11-03 16:00:00")]
        public DateHeure DateHeure { get; set; }
        //public List<DateHeure> DateHeure { get; set; }

        public override string ToString()
        {
            return " Request_State :" + Request_State + "  Request_Key :" + Request_Key +"\n"
                   + " Message :" + Message + "  Model_Run :" + Model_Run + " Source : " + Source + "\n"
                   + "\n" + " Meteo  |  " + DateHeure;
        }
    }

    public class DateHeure
    {
        public DateTime DateH;

        public DateHeure()
        {
            this.DateH = DateTime.Now;
        }

        [JsonPropertyName("temperature")]
        public Temperature Temperature { get; set; }

        [JsonPropertyName("pression")]
        public Pression Pression { get; set; }

        [JsonPropertyName("pluie")]
        public int? Pluie { get; set; }

        public override string ToString()
        {
  
            return "Date :" + this.DateH + "\n" + "            Temperature :" + Temperature
                    + "\n" + "            Pression :" + Pression+ "\n" + "            Pluie :" + Pluie;
 
            //return "Date :" + this.DateH.ToString("dd MMMM yyyy");
        }
    }

    public class Temperature
    {
        [JsonPropertyName("2m")]
        public double M { get; set; }
        [JsonPropertyName("sol")]
        public double Sol { get; set; }
        [JsonPropertyName("500hPa")]
        public double Pa1 { get; set; }
        [JsonPropertyName("850hPa")]
        public double Pa2 { get; set; }

        public override string ToString()
        {
            return "2m :" + this.M + " Sol :" + this.Sol + " 500hPa :" + this.Pa1 + " 850hPa :" + this.Pa2;
        }

    }

    public class Pression
    {
        [JsonPropertyName("niveau_de_la_mer")]
        public int NiveauDeMer { get; set; }


        public override string ToString()
        {
            return " Niveau De Mer :" + this.NiveauDeMer;
        }
    }

    public class Pluie
    {
        //public int Plui = 0;

        public override string ToString()
        {

            return this.ToString();
        }
    }
}
