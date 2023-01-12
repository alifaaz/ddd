using alidddd.Application.Common.Interfaces.Reoistories;

namespace alidddd.Infra.Repositories.User;

public  class UserRepository: IUserRepo
{
    private static List<Domain.Entitirs.User> _users;
    public Domain.Entitirs.User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(uu => uu.Email == email);
    }

    public void AddUser(Domain.Entitirs.User user)
    {
        _users.Add(user);
    }
}