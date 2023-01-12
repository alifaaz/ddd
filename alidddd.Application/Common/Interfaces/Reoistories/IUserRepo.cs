using alidddd.Domain.Entitirs;

namespace alidddd.Application.Common.Interfaces.Reoistories;

public interface IUserRepo
{
    User? GetUserByEmail(string email);
    void AddUser(User user);
}