using EmployeesManager.Domain.Constants;
using EmployeesManager.Domain.Models;
using EmployeesManager.Domain.Models.DTOs.Employee;
using System;

namespace EmployeesManager.Domain.Validators {
    public class EmployeeValidator {
        private ValidatorResult _validatorResult;

        public ValidatorResult Validate(UpdateEmployeeDto dto) {
            _validatorResult = new ValidatorResult();
            ValidateFirstNameField(dto.FirstName);
            ValidateLastNameField(dto.LastName);
            ValidatePatronymicField(dto.Patronymic);
            ValidateDepartmentField(dto.Department);
            ValidateBirthdayField(dto.Birthday);
            ValidateEmploymentDateField(dto.EmploymentDate);
            ValidateWageField(dto.Wage);

            return _validatorResult;
        }

        public ValidatorResult Validate(CreateEmployeeDto dto) {
            _validatorResult = new ValidatorResult();
            ValidateFirstNameField(dto.FirstName);
            ValidateLastNameField(dto.LastName);
            ValidatePatronymicField(dto.Patronymic);
            ValidateDepartmentField(dto.Department);
            ValidateBirthdayField(dto.Birthday);
            ValidateEmploymentDateField(dto.EmploymentDate);
            ValidateWageField(dto.Wage);

            return _validatorResult;
        }

        private bool ValidateFirstNameField(string value) {
            var result = true;
            if (String.IsNullOrEmpty(value)) {
                _validatorResult.Errors.Add(LocalizationKeys.EMPLOYEE_FIRST_NAME_FIELD_REQUIRED);
                result = false;
            }

            if (value.Length > 64) {
                _validatorResult.Errors.Add(LocalizationKeys.EMPLOYEE_FIRST_NAME_GREATER_MAX_LENGTH);
                result = false;
            }

            return result;
        }

        private bool ValidateLastNameField(string value) {
            var result = true;
            if (String.IsNullOrEmpty(value)) {
                _validatorResult.Errors.Add(LocalizationKeys.EMPLOYEE_LAST_NAME_FIELD_REQUIRED);
                result = false;
            }

            if (value.Length > 64) {
                _validatorResult.Errors.Add(LocalizationKeys.EMPLOYEE_LAST_NAME_GREATER_MAX_LENGTH);
                result = false;
            }

            return result;
        }

        private bool ValidatePatronymicField(string value) {
            var result = true;
            if (String.IsNullOrEmpty(value)) {
                _validatorResult.Errors.Add(LocalizationKeys.EMPLOYEE_PATRONYMIC_FIELD_REQUIRED);
                result = false;
            }

            if (value.Length > 64) {
                _validatorResult.Errors.Add(LocalizationKeys.EMPLOYEE_PATRONYMIC_GREATER_MAX_LENGTH);
                result = false;
            }

            return result;
        }

        private bool ValidateDepartmentField(string value) {
            var result = true;
            if (String.IsNullOrEmpty(value)) {
                _validatorResult.Errors.Add(LocalizationKeys.EMPLOYEE_DEPARTMENT_FIELD_REQUIRED);
                result = false;
            }

            return result;
        }

        private bool ValidateBirthdayField(DateTime value) {
            var result = true;
            if (value == null) {
                _validatorResult.Errors.Add(LocalizationKeys.EMPLOYEE_BIRTHDAY_FIELD_REQUIRED);
                result = false;
            }

            return result;
        }

        private bool ValidateEmploymentDateField(DateTime value) {
            var result = true;
            if (value == null) {
                _validatorResult.Errors.Add(LocalizationKeys.EMPLOYEE_EMPLOYMENT_DATE_FIELD_REQUIRED);
                result = false;
            }

            return result;
        }

        private bool ValidateWageField(decimal value) {
            var result = true;

            return result;
        }
    }
}
