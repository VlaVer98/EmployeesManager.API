using System;

namespace EmployeesManager.DAL.Entities.Base {
    public abstract class BaseEntity<TKey>
        where TKey : IEquatable<TKey> {
        public TKey Id { get; set; }
    }
}
