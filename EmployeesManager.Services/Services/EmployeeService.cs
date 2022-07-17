using AutoMapper;
using EmployeesManager.DAL.Contracts;
using EmployeesManager.DAL.Entities;
using EmployeesManager.Domain.Constants;
using EmployeesManager.Domain.Models;
using EmployeesManager.Domain.Models.DTOs.Employee;
using EmployeesManager.Domain.Validators;
using EmployeesManager.Services.Contracts;
using EmployeesManager.Services.Services.Base;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace EmployeesManager.Services.Services {
    public class EmployeeService : BaseService<EmployeeService>, IEmployeeService {
        public EmployeeService(
            IUnitOfWork unitOfWork,
            ILogger<EmployeeService> logger,
            IMapper mapper)
            : base(unitOfWork, logger, mapper) { }

        public ServiceResult<EmployeeDto> Get(Guid id) {
            var entity = _unitOfWork.EmployeeRepository.FindById(id);
            if (entity == null) {
                var errors = new List<string>() { LocalizationKeys.ENTRY_NOT_FOUND };
                return new ServiceResult<EmployeeDto>(errors);
            }

            var dto = _mapper.Map<EmployeeDto>(entity);
            return new ServiceResult<EmployeeDto>(dto);
        }

        public ServiceResult<IEnumerable<EmployeeDto>> GetAll() {
            var entities = _unitOfWork.EmployeeRepository.GetAll();

            var dto = _mapper.Map<IEnumerable<EmployeeDto>>(entities);
            return new ServiceResult<IEnumerable<EmployeeDto>>(dto);
        }

        public ServiceResult<EmployeeDto> Create(CreateEmployeeDto dto) {
            try {
                ValidatorResult validatorResult = Validate(dto);

                if (!validatorResult.IsSuccessful) {
                    return new ServiceResult<EmployeeDto>(validatorResult.Errors);
                }

                Employee entity = BuildEntity(dto);

                _unitOfWork.EmployeeRepository.Add(entity);

                _unitOfWork.Commit();

                return new ServiceResult<EmployeeDto>(true,
                    LocalizationKeys.ENTRY_CREATE_SUCCESS,
                    Get(entity.Id).Data);
            } catch (Exception ex) {
                _logger.LogError(ex, "Create entry exception");
                throw;
            }
        }

        public ServiceResult<EmployeeDto> Update(UpdateEmployeeDto dto) {
            try {
                ValidatorResult validatorResult = Validate(dto);

                if (!validatorResult.IsSuccessful) {
                    return new ServiceResult<EmployeeDto>(validatorResult.Errors);
                }

                Employee entity = _unitOfWork.EmployeeRepository.FindById(dto.Id);

                if (entity == null) {
                    return new ServiceResult<EmployeeDto>(false, LocalizationKeys.ENTRY_NOT_FOUND);
                }

                _mapper.Map(dto, entity);

                _unitOfWork.Commit();

                return new ServiceResult<EmployeeDto>(
                    true,
                    LocalizationKeys.ENTRY_UPDATE_SUCCESS,
                    _mapper.Map<EmployeeDto>(entity));
            } catch (Exception ex) {
                _logger.LogError(ex, "Update entry exception");
                throw;
            }
        }

        public ServiceResult Delete(Guid id) {
            try {
                Employee entity = _unitOfWork.EmployeeRepository.FindById(id);

                if (entity == null) {
                    return new ServiceResult(false, LocalizationKeys.ENTRY_NOT_FOUND);
                }

                _unitOfWork.EmployeeRepository.Delete(entity);
                _unitOfWork.Commit();

                return new ServiceResult(true, LocalizationKeys.ENTRY_REMOVE_SUCCESS);
            } catch (Exception ex) {
                _logger.LogError(ex, "Delete entry exception");
                throw;
            }
        }

        protected virtual Employee BuildEntity(CreateEmployeeDto dto) {
            Employee entity = new Employee();
            entity.Id = Guid.NewGuid();

            _mapper.Map(dto, entity);

            return entity;
        }

        protected ValidatorResult Validate(CreateEmployeeDto dto) {
            EmployeeValidator validator = new EmployeeValidator();
            return validator.Validate(dto);
        }

        protected ValidatorResult Validate(UpdateEmployeeDto dto) {
            EmployeeValidator validator = new EmployeeValidator();
            return validator.Validate(dto);
        }
    }
}
