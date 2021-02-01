using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using WebServiceApi_Web.Entities;

namespace WebServiceApi_Web.Controllers
{
    public class ProduitController : ApiController
    {
        private static IList<Produit> ListeProduits { get; set; } = new List<Produit>();
        // GET: api/Produit
        public IList<Produit> Get()
        {
            return ListeProduits;
        }

        // GET: api/Produit/5
        public HttpResponseMessage Get(int id)
        {
            if (id <= 0)
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, " L'id " + id +"entré n'est pas autorisé");

            var produit = ListeProduits.FirstOrDefault(x => x.Id == id);
            if (produit != null)
                return Request.CreateResponse(HttpStatusCode.OK, produit);

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, " L'Id : " + id +"  n'existe pas ...!");
        }

        // PATCH: api/Client/5
        public HttpResponseMessage Patch(uint id, [FromBody] Produit produit)
        {

            return null;
        }

        // POST: api/Produit
        public HttpResponseMessage Post([FromBody]Produit produit)
        {
            if (string.IsNullOrEmpty(produit?.Categorie) || produit.Prix <= 0)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, " La Catégorie et le prix sont Obligatoire");

            int maxId = 0;

            if (ListeProduits.Count > 0)
                maxId = ListeProduits.Max(x => x.Id);

            produit.Id = maxId + 1;
            ListeProduits.Add(produit);

            return Request.CreateResponse(HttpStatusCode.OK, produit);
        }

        // PUT: api/Produit/5
        public HttpResponseMessage Put(int id, [FromBody] Produit produit)
        {
            var produit1 = ListeProduits.FirstOrDefault(x => x.Id == id);
            if(produit != null)
            {
                produit1.Categorie = produit.Categorie;
                produit1.Prix = produit.Prix;
                produit1.Type = produit.Type;
                produit1.Taille = produit.Taille;
                produit1.Quantite = produit.Quantite;
                return Request.CreateResponse(HttpStatusCode.Accepted, "produit Modifié ... !");
            }
            else
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, " L'Id : " + id + "  n'existe pas ...!");
          
        }

        // DELETE: api/Produit/5
        public HttpResponseMessage Delete(int id)
        {
            var produit = ListeProduits.FirstOrDefault(x => x.Id == id);
                if (produit != null)
                {
                ListeProduits.Remove(produit);
                return Request.CreateResponse(HttpStatusCode.OK, "client supprimé ...");
                }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "client non trouvé ...");
        }
    }
}
