using ApiELection.models;

namespace ApiELection.Interfaces
{
    public interface InterfaceBureau
    {
        Task<IEnumerable<Bureau>> GetAll();
        Task<Bureau> Get(int id);
        Task<Bureau> AddB(Bureau bureau);
        Task Delete(int id);
        Task<Bureau> Update(int id, Bureau bureau);
    }
}
