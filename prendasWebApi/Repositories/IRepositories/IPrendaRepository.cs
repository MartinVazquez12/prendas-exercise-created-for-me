using prendasWebApi.Models;

namespace prendasWebApi.Repositories.IRepositories
{
    public interface IPrendaRepository
    {
        Task<List<Prenda>> GetAllPrendas();
        Task<Prenda> GetPrendaById(Guid id);
        Task<Prenda> AddPrenda(Prenda prenda);
        Task<bool> PrendaByColorExiste(string nombre);
    }
}
