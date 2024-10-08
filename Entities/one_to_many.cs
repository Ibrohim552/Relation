namespace Relations.Entities;

public class Company
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    
    public List<Employee> Employees { get; set; } = new();
}

public class Employee
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
    
    
    public int CompanyId { get; set; }
    public Company Company { get; set; } = null!;
}