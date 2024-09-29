using prendasWebApi.Dtos;
using prendasWebApi.Models;

namespace prendasWebApi.Services.Interfaz
{
    public interface IRecuperatorioService
    {
        Task<ApiResponseDto<List<PrendaDto>>> GetPrendasAsync();
        Task<ApiResponseDto<List<MarcaDto>>> GetMarcasAsync();
        Task<ApiResponseDto<PrendaDto>> GetPrendaById(Guid id);
        Task<ApiResponseDto<PrendaPostDto>> PostPrenda(PrendaPostDto prendaPostDto);
    }
}
