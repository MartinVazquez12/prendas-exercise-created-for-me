using prendasWebApi.Models;

namespace prendasWebApi.Dtos
{
    public class PrendaPostDto
    {
        public Guid id_post { get; set; }

        public string nombrepost { get; set; } = null!;

        public string tallepost { get; set; } = null!;

        public string colorpost { get; set; } = null!;

        public Guid id_marca { get; set; }

    }
}
