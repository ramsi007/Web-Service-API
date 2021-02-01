//using System;
//using System.Threading.Tasks;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Collections.Generic;
//using System.Text.Json;

//namespace WebApliClientRest
//{
//    class Program
//    {
//        private static readonly HttpClient client = new HttpClient();

//        public static async Task Main(string[] args)
//        {
//            var repositories = await ProcessRepositories();

//            foreach (var repo in repositories)
//            {
//                Console.WriteLine(repo.Id == null ? "Id = absent !" : repo.Id.ToString());
//                Console.WriteLine(repo.Name == null ? "Name = absent !" : repo.Name);
//                Console.WriteLine(repo.Description == null ? "Description = absente !" : repo.Description);
//                Console.WriteLine(repo.Fork == null ? "Fork = absente !" : repo.Fork.ToString());
//                Console.WriteLine(repo.HomePage == null ? "HomePage = absente !" : repo.HomePage.ToString());
//                Console.WriteLine(repo.CreationDate == null ? "CreationDate = absente !" : repo.CreationDate.ToString());
//                Console.WriteLine(repo.PushedAt == null ? "PushedAt = absent !" : repo.PushedAt.ToString());
//                Console.WriteLine(repo.LastPush == null ? "LastPush = absent !" : repo.LastPush.ToString());
//                Console.WriteLine();
//            }

//            //repositories.ForEach(x => Console.WriteLine(x.Licence));

//            //foreach (var repo in repositories)
//            //{
//            //    Console.WriteLine(repo);
//            //    Console.WriteLine();
//            //}

//            Console.Read();
//        }

//        // on utilise Task<T> pour la valeur de retour car on a marqué cette méthode asynchrone (mot clé async)
//        private static async Task<List<Repository>> ProcessRepositories()
//        {
//            client.DefaultRequestHeaders.Accept.Clear();

//            // on configure le client http pour accepter les json du GitHub
//            client.DefaultRequestHeaders.Accept.Add(
//                new MediaTypeWithQualityHeaderValue("application/json"));

//            // on ajoute un en-tête d’agent utilisateur à toutes les requêtes à partir de cet objet client http
//            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
//            client.DefaultRequestHeaders.Add("User-Name", "Ryadh");

//            //récupération des noms des espaces de stockage du repo
//            var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");

//            //Désérialisation du JSON reçu en des objets C#
//            var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);

//            return repositories;
//        }
//    }
//}

