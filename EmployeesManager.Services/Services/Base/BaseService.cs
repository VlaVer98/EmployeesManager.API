using AutoMapper;
using EmployeesManager.DAL.Contracts;
using Microsoft.Extensions.Logging;

namespace EmployeesManager.Services.Services.Base {
    public abstract class BaseService<TService> {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly ILogger<TService> _logger;
        protected readonly IMapper _mapper;

        public BaseService(
            IUnitOfWork unitOfWork,
            ILogger<TService> logger,
            IMapper mapper) {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
    }
}
