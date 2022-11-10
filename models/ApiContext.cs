using Microsoft.EntityFrameworkCore;

namespace ApiELection.models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        { }

        public DbSet<Electeur> Electeur { get; set; }
        public DbSet<Bureau> Bureau { get; set; }

        public DbSet<Centre> Centre { get; set; }


        //Enregistrer l'etat de la BD
        public new async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }

    }
   
}
