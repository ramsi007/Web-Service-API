using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Text.Json;

namespace WebApiClientRestVersion2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var repositories = await ProcessRepositories();
            foreach(var repo in repositories)
            {
                //Console.WriteLine(repo.Id == null ? "Id Abscent" : repo.Id.ToString());
                //Console.WriteLine(repo.Name == null ? " Le nom N'existe pas" : repo.Name);
                //Console.WriteLine(repo.Description == null ? "Description introuvable" : repo.Description);
                //Console.WriteLine(repo.HomePage == null ? "Home page Abscente" : repo.HomePage.ToString());
                //Console.WriteLine(repo.Watchers == null ? "Le watcher n'existe pas " : repo.Watchers.ToString());
                //Console.WriteLine(repo.IsFork == null ? "Fork introuvable " : repo.IsFork.ToString());
                //Console.WriteLine("");
                //Console.WriteLine(repo);
                //Console.WriteLine(repo);
                //Console.WriteLine(repo);

                //Console.WriteLine(repo.Id == null ? "Id Abscent" : repo.ToString());
                //Console.WriteLine(repo);
                //Console.WriteLine(repo);
                //Console.WriteLine(repo.HomePage == null ? "Home page Abscente" : repo.ToString());
                //Console.WriteLine(repo.Watchers == null ? "Le watcher n'existe pas " : repo.ToString());
                //Console.WriteLine(repo.IsFork == null ? "Fork introuvable " : repo.ToString());
                //Console.WriteLine("");
                //Console.WriteLine(repo);
                //Console.WriteLine(repo);
                Console.WriteLine(repo);

                Console.WriteLine("");
            }
        }

        private static readonly HttpClient client = new HttpClient();


        private static async Task<List<Repository>> ProcessRepositories()
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
            //var stringTask = client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");
            // La chaîne message est disponible lorsque la tâche est terminée
            //var message = await stringTask;

            var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            var message = await streamTask;
            //récupération des noms des espaces de stockage du repo
            var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);

            return repositories;
        }
    }
}
