using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.Brand.Request;
using Gymmetry.Domain.DTO;
using Gymmetry.Repository.Services.Interfaces;
using AutoMapper;

namespace Gymmetry.Application.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;
        private readonly IMapper _mapper;

        public BrandService(IBrandRepository brandRepository, ILogChangeService logChangeService, ILogErrorService logErrorService, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
            _mapper = mapper;
        }

        public async Task<ApplicationResponse<Brand>> CreateBrandAsync(AddBrandRequest request)
        {
            try
            {
                var brand = _mapper.Map<Brand>(request);
                var created = await _brandRepository.CreateBrandAsync(brand);
                return new ApplicationResponse<Brand>
                {
                    Success = true,
                    Message = "Marca creada correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<Brand>
                {
                    Success = false,
                    Message = "Error técnico al crear la marca.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<Brand>> GetBrandByIdAsync(Guid id)
        {
            var brand = await _brandRepository.GetBrandByIdAsync(id);
            if (brand == null)
            {
                return new ApplicationResponse<Brand>
                {
                    Success = false,
                    Message = "Marca no encontrada.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<Brand>
            {
                Success = true,
                Data = brand
            };
        }

        public async Task<ApplicationResponse<IEnumerable<Brand>>> GetAllBrandsAsync()
        {
            var brands = await _brandRepository.GetAllBrandsAsync();
            return new ApplicationResponse<IEnumerable<Brand>>
            {
                Success = true,
                Data = brands
            };
        }

        public async Task<ApplicationResponse<bool>> UpdateBrandAsync(UpdateBrandRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            try
            {
                var brandBefore = await _brandRepository.GetBrandByIdAsync(request.Id);
                var brand = _mapper.Map<Brand>(request);
                var updated = await _brandRepository.UpdateBrandAsync(brand);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("Brand", brandBefore, userId, ip, invocationId);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Marca actualizada correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar la marca (no encontrada o inactiva).",
                        ErrorCode = "NotFound"
                    };
                }
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Error técnico al actualizar la marca.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteBrandAsync(Guid id)
        {
            try
            {
                var deleted = await _brandRepository.DeleteBrandAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Marca eliminada correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Marca no encontrada o ya eliminada.",
                        ErrorCode = "NotFound"
                    };
                }
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Error técnico al eliminar la marca.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<Brand>>> FindBrandsByFieldsAsync(Dictionary<string, object> filters)
        {
            var brands = await _brandRepository.FindBrandsByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<Brand>>
            {
                Success = true,
                Data = brands
            };
        }
    }
}
