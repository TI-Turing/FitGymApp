using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.Bill.Request;
using Gymmetry.Domain.DTO;
using Gymmetry.Repository.Services.Interfaces;
using AutoMapper;

namespace Gymmetry.Application.Services
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _billRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;
        private readonly IMapper _mapper;

        public BillService(IBillRepository billRepository, ILogChangeService logChangeService, ILogErrorService logErrorService, IMapper mapper)
        {
            _billRepository = billRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
            _mapper = mapper;
        }

        public async Task<ApplicationResponse<Bill>> CreateBillAsync(AddBillRequest request)
        {
            try
            {
                var bill = _mapper.Map<Bill>(request);
                var created = await _billRepository.CreateBillAsync(bill);
                return new ApplicationResponse<Bill>
                {
                    Success = true,
                    Message = "Factura creada correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<Bill>
                {
                    Success = false,
                    Message = "Error técnico al crear la factura.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<Bill>> GetBillByIdAsync(Guid id)
        {
            var bill = await _billRepository.GetBillByIdAsync(id);
            if (bill == null)
            {
                return new ApplicationResponse<Bill>
                {
                    Success = false,
                    Message = "Factura no encontrada.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<Bill>
            {
                Success = true,
                Data = bill
            };
        }

        public async Task<ApplicationResponse<IEnumerable<Bill>>> GetAllBillsAsync()
        {
            var bills = await _billRepository.GetAllBillsAsync();
            return new ApplicationResponse<IEnumerable<Bill>>
            {
                Success = true,
                Data = bills
            };
        }

        public async Task<ApplicationResponse<bool>> UpdateBillAsync(UpdateBillRequest request)
        {
            try
            {
                var billBefore = await _billRepository.GetBillByIdAsync(request.Id);
                var bill = _mapper.Map<Bill>(request);
                var updated = await _billRepository.UpdateBillAsync(bill);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("Bill", billBefore, bill.Id);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Factura actualizada correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar la factura (no encontrada o inactiva).",
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
                    Message = "Error técnico al actualizar la factura.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteBillAsync(Guid id)
        {
            try
            {
                var deleted = await _billRepository.DeleteBillAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Factura eliminada correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Factura no encontrada o ya eliminada.",
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
                    Message = "Error técnico al eliminar la factura.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<Bill>>> FindBillsByFieldsAsync(Dictionary<string, object> filters)
        {
            var bills = await _billRepository.FindBillsByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<Bill>>
            {
                Success = true,
                Data = bills
            };
        }
    }
}
