using ApiELection.Controllers;
using System.Net;
using ApiELection.Interfaces;
using ApiELection.models;
using Microsoft.EntityFrameworkCore;

namespace ApiELection.Services
{
    public class ServiceElecteur : InterfaceElecteur
    {

        private readonly ApiContext apiContext;

        public ServiceElecteur(ApiContext apiContext)
        {
            this.apiContext = apiContext;
        }


        //Fonction d'ajout
        // Il faut ajouter si le bureau n'est pas plein au cas contraire l'affecter a un autre bureau
        public async Task<Electeur> AddE(Electeur electeur)
        {
            Bureau bureau = new Bureau();
            if (bureau.Electeurs.Count <= bureau.Capacite && bureau.Centre.Lieu == electeur.Lieu_residence)
            {
               
                apiContext.Electeur.Add(electeur);
                await apiContext.SaveChangesAsync();
            }
            else
            {
              
                throw new HttpResponseException("Bureau plein");
            }

            return electeur;
        }

        //
        public async Task Delete(int id)
        {
            var req = apiContext.Electeur.FirstOrDefault(req => req.NumE== id);

            if (req is null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            apiContext.Electeur.Remove(req);
            await apiContext.SaveChangesAsync();

        }

        //
        public async Task<Electeur> Get(int id)
        {
            var e = await apiContext.Bureau.FirstOrDefaultAsync(e => e.NumE == id);
            if (e is null) throw new HttpResponseException(HttpStatusCode.NotFound);

            return e;
        }

        //
        public async Task<IEnumerable<Electeur>> GetAll()
        {
            return await apiContext.Electeur.AsTracking().ToListAsync();
        }

        //
        public async Task<Electeur> Update(int id, Electeur electeur)
        {
            if (id != electeur.NumE)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            apiContext.Update(electeur);
            await apiContext.SaveChangesAsync();

            return electeur;

        }
    }
}
