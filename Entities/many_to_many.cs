namespace Relations.Entities;

public class Student
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;

    public ICollection<StudentGroup> StudentGroups { get; set; } = null!;
}

public class StudentGroup
{
    public int Id { get; set; }

    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;

    public int GroupId { get; set; }
    public Group Group { get; set; } = null!;
}

public class Group
{
    public int Id { get; set; }

    public string Name { get; set; }=null!;

    public ICollection<StudentGroup> StudentGroups { get; set; } =null!;
}