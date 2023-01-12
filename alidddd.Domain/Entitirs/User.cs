namespace alidddd.Domain.Entitirs;

public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Pwd { get; set; }
    public Guid Id { get; set; } = Guid.NewGuid();
}