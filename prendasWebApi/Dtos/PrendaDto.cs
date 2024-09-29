using prendasWebApi.Models;

namespace prendasWebApi.Dtos
{
    public class PrendaDto
    {
        public Guid id_prenda { get; set; }

        public string nombredto { get; set; } = null!;

        public string talledto { get; set; } = null!;

        public string colordto { get; set; } = null!;

        public string nombre_marca { get; set; } = null!;

    }
}
