using System;
using System.Collections.Generic;

namespace EmployeesManager.Domain.Models
{
    public class ServiceResult
    {
        public bool IsSuccessful { get; set; }
        public IList<string> Errors { get; set; } = new List<string>();
        public string Message { get; set; }

        public ServiceResult() { }

        public ServiceResult(bool isSuccessful)
        {
            IsSuccessful = isSuccessful;
            Message = string.Empty;
        }

        public ServiceResult(bool isSuccessful, string message)
            : this(isSuccessful)
        {
            Message = message;
        }

        public ServiceResult(IList<string> errors)
        {
            IsSuccessful = false;
            Errors = errors;
        }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T Data { get; set; }

        public ServiceResult() { }

        public ServiceResult(bool isSuccessful) : base(isSuccessful) { }

        public ServiceResult(bool isSuccessful, string message) : base(isSuccessful, message) { }

        public ServiceResult(bool isSuccessful, string message, T data) : base(isSuccessful, message)
        {
            Data = data;
        }

        public ServiceResult(T data)
        {
            IsSuccessful = true;
            Data = data;
        }

        public ServiceResult(IList<string> errors) : base(errors) { }
    }
}
