using iMaxwell.Common.Models;

namespace iMaxwell.EmployeeClient.Models
{
    public class Department : IDepartmentModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} Name:{Name}";
        }
    }
}
