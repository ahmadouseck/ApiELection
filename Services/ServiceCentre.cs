using ApiELection.Controllers;
using System.Net;
using ApiELection.Interfaces;
using ApiELection.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.OpenApi.Writers;

namespace ApiELection.Services
{
    public class ServiceCentre : InterfaceCentre
    {


        private readonly ApiContext apiContext;


        public ServiceCentre(ApiContext context)
        {
            apiContext = context;
        }

        //
        public async Task<IEnumerable<Centre>> GetAll()
        {
            return await apiContext.Centre.AsTracking().ToListAsync();
           
        }

        //
        public async Task<Centre> Get(int id)
        {

            return await apiContext.Centre.FindAsync(id);
            
        }

        //
        public async Task<Centre> AddC(Centre centre)
        {

            if (!apiContext.Centre.Any(c=> c.NumC == centre.NumC))
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }
            apiContext.Centre.Add(centre);
            await apiContext.SaveChangesAsync();

            return centre;
        }

        //
        public async Task Delete(int id)
        {
            var req = await apiContext.Centre.FindAsync(id);

            if (req == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            apiContext.Centre.Remove(req);
            await apiContext.SaveChangesAsync();

            throw new HttpResponseException(HttpStatusCode.NoContent);

        }

        //
        public async Task Update(int id, Centre centre)
        {

            if (id != centre.NumC)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var ftask = await apiContext.Centre.FindAsync(id);
            if (ftask == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            ftask.Nom = centre.Nom;
            ftask.Lieu = centre.Lieu;
            ftask.NombreBureau = centre.NombreBureau;
             await apiContext.SaveChangesAsync();
 

            throw new HttpResponseException(HttpStatusCode.NoContent);

        }

     
       

      

       
    }
}
