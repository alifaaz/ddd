namespace alidddd.Application.Auth;

// i cant access contract due to clean role
public record AuthResult(Guid Id,string Name,string Role,string Token);