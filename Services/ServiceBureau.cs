using ApiELection.Controllers;
using System.Net;
using ApiELection.Interfaces;
using ApiELection.models;
using Microsoft.EntityFrameworkCore;

namespace ApiELection.Services
{


    public class ServiceBureau : InterfaceBureau
    {

        private readonly ApiContext apiContext;
       
        public ServiceBureau(ApiContext context)
        {
            apiContext = context;
        }

        //
        public async Task<Bureau> AddB(Bureau bureau)
        {
            if (!apiContext.Bureau.Any(b => b.NumB == bureau.NumB))
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }
            apiContext.Bureau.Add(bureau);
            await apiContext.SaveChangesAsync();

            return bureau;
        }

        //
        public async Task Delete(int id)
        {
            var req = await apiContext.Bureau.FindAsync(id);

            if (req == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            apiContext.Bureau.Remove(req);
            await apiContext.SaveChangesAsync();

            throw new HttpResponseException(HttpStatusCode.NoContent);
        }

        //
        public async Task<Bureau> Get(int id)
        {
            return await apiContext.Bureau.FindAsync(id);
        }

        //
        public async Task<IEnumerable<Bureau>> GetAll()
        {
            return await apiContext.Bureau.AsTracking().ToListAsync();
        }

        //
        public  async Task Update(int id, Bureau bureau)
        {
            if (id != bureau.NumB)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var ftask = await apiContext.Bureau.FindAsync(id);
            if (ftask == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            ftask.Nom = bureau.Nom;
            ftask.Capacite = bureau.Capacite;
            ftask.Centre = bureau.Centre;
            await apiContext.SaveChangesAsync();


            throw new HttpResponseException(HttpStatusCode.NoContent);
        }
    }
}
