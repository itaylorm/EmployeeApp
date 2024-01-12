namespace iMaxwell.Common.Models;

public class DepartmentModel : IDepartmentModel
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}";
    }
}
