namespace Relations.Entities;

public class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public Profile Profile { get; set; } = null!;
}

public class Profile
{
    public int Id { get; set; }

    public string UserName { get; set; }=null!;
    

    public int UserId { get; set; }

    public User User { get; set; } = null!;
}