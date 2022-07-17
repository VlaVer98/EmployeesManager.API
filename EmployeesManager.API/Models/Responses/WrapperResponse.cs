using System.Collections.Generic;

namespace EmployeesManager.API.Models.Responses {
    public class WrapperResponse<T> {
        public bool IsSuccessful { get; set; }
        public T Result { get; set; }
        public IList<string> Errors { get; set; }
        public string Message { get; set; }
    }
}
