using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManager.Domain.Models
{
    public class ValidatorResult
    {
        public ValidatorResult()
        {
            Errors = new List<string>();
        }
        public bool IsSuccessful
        {
            get
            {
                return Errors.Count == 0 ? true : false;
            }
        }

        public IList<string> Errors { get; set; }
    }
}
