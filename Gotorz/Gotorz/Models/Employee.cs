using System.Text.Json.Serialization;

namespace Gotorz.Models
{
    public class Employee
    {
        [JsonPropertyName("employeeId")]
        public int EmployeeId { get; set; }
        [JsonPropertyName("employeeName")]
        public string EmployeeName { get; set; }
    }
}
