using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManager.Domain.Models.DTOs.Base
{
    public abstract class BaseEntityDto<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }
}
