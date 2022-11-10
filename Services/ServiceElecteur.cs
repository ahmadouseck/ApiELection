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


        //
        public async Task<Electeur> AddE(Electeur electeur)
        {
            if (!apiContext.Electeur.Any(e => e.NumE == electeur.NumE))
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }
            apiContext.Electeur.Add(electeur);
            await apiContext.SaveChangesAsync();

            return electeur;
        }

        //
        public async Task Delete(int id)
        {
            var req = await apiContext.Electeur.FindAsync(id);

            if (req == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            apiContext.Electeur.Remove(req);
            await apiContext.SaveChangesAsync();

            throw new HttpResponseException(HttpStatusCode.NoContent);
        }

        //
        public async Task<Electeur> Get(int id)
        {
            return await apiContext.Electeur.FindAsync(id);
        }

        //
        public async Task<IEnumerable<Electeur>> GetAll()
        {
            return await apiContext.Electeur.AsTracking().ToListAsync();
        }

        //
        public async Task Update(int id, Electeur electeur)
        {
            if (id != electeur.NumE)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var ftask = await apiContext.Electeur.FindAsync(id);
            if (ftask == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            ftask.Nom = electeur.Nom;
            ftask.Prenom = electeur.Prenom;
            ftask.Lieu_residence = electeur.Lieu_residence;
            ftask.Bureau = electeur.Bureau;
            await apiContext.SaveChangesAsync();


            throw new HttpResponseException(HttpStatusCode.NoContent);
        }
    }
}
