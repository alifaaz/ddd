namespace alidddd.Application.Common.Interfaces;

public interface IJwtGenerator
{
    string GenerateToke(Guid Id, string email);
    
}