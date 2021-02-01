using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Text.Json;

namespace Web_Service_Meteo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var Meteo = await ProcessMeteos();
            //Console.WriteLine(Meteo.Request_State.ToString());
            //Console.WriteLine(Meteo.Request_Key);
            //Console.WriteLine(Meteo.Message);
            //Console.WriteLine(Meteo.Model_Run);
            //Console.WriteLine(Meteo.Source.ToString());

            Console.WriteLine(Meteo);

            //DateTime date = new DateTime();

            //Console.WriteLine(date.ToString("yyyy-MM-dd HH:mm:ss"));
            //DateHeure Date = new DateHeure();

            string DateF;
            DateTime StartDate = new DateTime(2020, 11, 03,16,00,00);
            DateTime EndDate = new DateTime(2020, 11, 11, 23,00,00);

            int Hours = 3;

            List<DateTime> dateList = new List<DateTime>();
            while (StartDate.AddHours(Hours) <= EndDate)
            {
                StartDate = StartDate.AddHours(Hours);
                //dateList.Add(StartDate);
                DateF = StartDate.ToString("yyyy-MM-dd HH:mm:ss");
                Console.WriteLine(DateF);
            }

            //IList<DateHeure> ListeDates = new List<DateHeure>();
            //foreach (DateHeure d in ListeDates)
            //{
            //    ListeDates.Add(d);
            //    Console.WriteLine(Meteo);
            //}



            //List<DateHeure> ListeDates = new List<DateHeure>();
            //foreach (var date in ListeDates)
            //{
            //    Console.WriteLine(date.Temperature.ToString());
            //    Console.WriteLine(date.Pression.ToString());
            //    Console.WriteLine(date.Pluie.ToString());
            //}

        }

        private static readonly HttpClient client = new HttpClient();


        private static async Task<Meteo> ProcessMeteos()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            // on configure le client http pour accepter les json du GitHub
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json")
            );
            // on ajoute un en-tête d’agent utilisateur à toutes les requêtes à partir de cet objet client http
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            // On effectue une requête web et on récupère la réponse
            // Cette méthode démarre une tâche qui effectue la requête web :
            //-Envoie la demande,
            //-Lit le flux de réponse
            //-puis, extrait le contenu à partir du flux.(flux = stream) 
            //var stringTask = client.GetStringAsync("https://www.infoclimat.fr/public-api/gfs/json?_ll=48.85341,2.3488&_auth=VE4CFQZ4UnADLlRjA3UBKAJqUmcKfFB3An4LaF86An9SOV4%2FVTUDZVE%2FBHkALws9BCkEZ1liVWUBagtzCHpSM1Q%2BAm4GbVI1A2xUMQMsASoCLFIzCipQdwJmC2RfLAJjUjJePVUoA2JROAR4ADELPgQwBHtZeVVsAWQLbAhhUjVUNgJmBmFSMgNqVCkDLAEwAmdSYwo0UG0CMgtvX2MCaFIwXjxVYAM0UTgEeAAzCzYENQRlWW9VbAFgC2QIelIuVE4CFQZ4UnADLlRjA3UBKAJkUmwKYQ%3D%3D&_c=17598868439872c4e802de6e54bb2a2f");
            // La chaîne message est disponible lorsque la tâche est terminée
            //var message = await stringTask;

            var streamTask = client.GetStreamAsync("https://www.infoclimat.fr/public-api/gfs/json?_ll=48.85341,2.3488&_auth=VE4CFQZ4UnADLlRjA3UBKAJqUmcKfFB3An4LaF86An9SOV4%2FVTUDZVE%2FBHkALws9BCkEZ1liVWUBagtzCHpSM1Q%2BAm4GbVI1A2xUMQMsASoCLFIzCipQdwJmC2RfLAJjUjJePVUoA2JROAR4ADELPgQwBHtZeVVsAWQLbAhhUjVUNgJmBmFSMgNqVCkDLAEwAmdSYwo0UG0CMgtvX2MCaFIwXjxVYAM0UTgEeAAzCzYENQRlWW9VbAFgC2QIelIuVE4CFQZ4UnADLlRjA3UBKAJkUmwKYQ%3D%3D&_c=17598868439872c4e802de6e54bb2a2f");
            var message = await streamTask;
            //récupération des noms des espaces de stockage du repo
            var meteos = await JsonSerializer.DeserializeAsync<Meteo>(await streamTask);

            return meteos;
        }
    }
}
