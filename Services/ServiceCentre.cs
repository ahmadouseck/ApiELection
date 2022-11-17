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
            var c = await apiContext.Centre.FirstOrDefaultAsync(c => c.NumC == id);
            if (c is null) throw new HttpResponseException(HttpStatusCode.NotFound);
        
            return c;
        }

        //Ajout
        public async Task<Centre> AddC(Centre centre)
        {

            apiContext.Centre.Add(centre);
            await apiContext.SaveChangesAsync();

            return centre;
        }

        //
        public async Task Delete(int id)
        {
            var req = apiContext.Centre.FirstOrDefault(req => req.NumC == id);

            if (req is null) 
                   throw new HttpResponseException(HttpStatusCode.NotFound);
            

            apiContext.Centre.Remove(req);
            await apiContext.SaveChangesAsync();



        }

        //
        public async Task<Centre> Update(int id, Centre centre)
        {
            if (id != centre.NumC)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            apiContext.Update(centre);
            await apiContext.SaveChangesAsync();

            return centre;
        }

        /*
        public IEnumerable<Centre> GetCentre()
        {

        return apiContext.Centre.ToList();
        }*/
    }
}
