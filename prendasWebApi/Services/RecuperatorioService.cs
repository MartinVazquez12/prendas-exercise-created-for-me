using AutoMapper;
using prendasWebApi.Dtos;
using prendasWebApi.Models;
using prendasWebApi.Repositories.IRepositories;
using prendasWebApi.Services.Interfaz;
using prendasWebApi.Validators;
using System.Net;

namespace prendasWebApi.Services
{
    public class RecuperatorioService : IRecuperatorioService
    {
        private readonly IPrendaRepository _prendaRepository;
        private readonly IMarcaRepository _marcaRepository;
        private readonly IMapper _mapper;
        private readonly PrendaPostDtoValidator _validator;

        public RecuperatorioService(
            IPrendaRepository prendaRepository,
            IMarcaRepository marcaRepository,
            IMapper mapper,
            PrendaPostDtoValidator validator)
        {
            _prendaRepository = prendaRepository;
            _marcaRepository = marcaRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<ApiResponseDto<List<MarcaDto>>> GetMarcasAsync()
        {
            var response = new ApiResponseDto<List<MarcaDto>>();

            var listMarcas = await _marcaRepository.GetAllMarcas();

            if (listMarcas != null && listMarcas.Count > 0)
            {
                var marcasDto = _mapper.Map<List<MarcaDto>>(listMarcas);
                response.Data = marcasDto;
                response.Success = true;
                response.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                response.SetError("No se encontraron marcas", HttpStatusCode.InternalServerError);
            }
            return response;
        }

        public async Task<ApiResponseDto<List<PrendaDto>>> GetPrendasAsync()
        {
            var response = new ApiResponseDto<List<PrendaDto>>();

            var listPrendas = await _prendaRepository.GetAllPrendas();

            if (listPrendas != null && listPrendas.Count > 0)
            {
                var prendasDto = _mapper.Map<List<PrendaDto>>(listPrendas);
                response.Data = prendasDto;
                response.Success = true;
                response.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                response.SetError("No se encontraron prendas", HttpStatusCode.InternalServerError);
            }
            return response;
        }

        public async Task<ApiResponseDto<PrendaDto>> GetPrendaById(Guid id)
        {
            var response = new ApiResponseDto<PrendaDto>();

            var prenda = await _prendaRepository.GetPrendaById(id);

            if (prenda != null)
            {
                var prendaDto = _mapper.Map<PrendaDto>(prenda);
                response.Data = prendaDto;
                response.Success = true;
                response.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                response.SetError("No se encontro prenda con ese id", HttpStatusCode.InternalServerError);
            }
            return response;
        }

        public async Task<ApiResponseDto<PrendaPostDto>> PostPrenda(PrendaPostDto prendaPostDto)
        {
            var response = new ApiResponseDto<PrendaPostDto>();

            var validacion = await _validator.ValidateAsync(prendaPostDto);
            if (!validacion.IsValid)
            {
                response.Success = false;
                return response;
            }
            try
            {
                var existePrendaConColor = await _prendaRepository.PrendaByColorExiste(prendaPostDto.nombrepost);

                if (existePrendaConColor)
                {
                    response.Success = false;
                    response.SetError("Ya existe una prenda con ese color", HttpStatusCode.BadRequest);
                    return response;
                }

                var prenda = _mapper.Map<Prenda>(prendaPostDto);
                prenda.Id = Guid.NewGuid();

                await _prendaRepository.AddPrenda(prenda);

                var prendaAdd = _mapper.Map<PrendaPostDto>(prenda);
                response.Success = true;
                response.Data = prendaAdd;
                response.StatusCode = HttpStatusCode.OK;
                return response;
            }
            catch (Exception)
            {
                response.SetError("Error al añadir la prenda", HttpStatusCode.InternalServerError);
                throw;
            }


        }
    }
}
