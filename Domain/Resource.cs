using System.Collections.Generic;

namespace Domain
{
    public class Resource
    {
        public string Name { get; set; } = "Employees";
        public List<Employee> Data { get; } = new List<Employee>();
        public string Field { get; set; } = "employeeId";
        public string ValueField { get; set; } = "value";
        public string TextField { get; set; } = "text";
    }
}