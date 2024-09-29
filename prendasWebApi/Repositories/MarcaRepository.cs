using Microsoft.EntityFrameworkCore;
using prendasWebApi.Models;
using prendasWebApi.Repositories.IRepositories;

namespace prendasWebApi.Repositories
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly PrendasDbContext _context;

        public MarcaRepository(PrendasDbContext context)
        {
            _context = context;
        }
        public async Task<List<Marca>> GetAllMarcas()
        {
            return await _context.Marcas.ToListAsync();
        }
    }
}
