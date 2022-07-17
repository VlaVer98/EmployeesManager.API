using AutoMapper;
using EmployeesManager.API.Models.Responses;
using EmployeesManager.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesManager.API.Controllers.Base {
    [ApiController]
    public class BaseController : ControllerBase {
        protected readonly IMapper _mapper;

        public BaseController(IMapper mapper) {
            _mapper = mapper;
        }

        public WrapperResponse<TResponse> Success<TResponse, TDto>(ServiceResult<TDto> serviceResult) {
            return new WrapperResponse<TResponse>() {
                IsSuccessful = serviceResult.IsSuccessful,
                Result = _mapper.Map<TResponse>(serviceResult.Data),
                Errors = serviceResult.Errors,
                Message = serviceResult.Message
            };
        }

        public WrapperResponse<TResponse> Success<TResponse>(ServiceResult serviceResult)
            where TResponse : class {
            return new WrapperResponse<TResponse>() {
                IsSuccessful = serviceResult.IsSuccessful,
                Result = null,
                Errors = serviceResult.Errors,
                Message = serviceResult.Message
            };
        }
    }
}
