using alidddd.Application.Common.Interfaces;
using alidddd.Application.Common.Interfaces.Reoistories;
using alidddd.Domain.Entitirs;

namespace alidddd.Application.Auth;

public class AuthService:IAuthService
{
    private readonly IJwtGenerator _jwtGenerator;
    private readonly IUserRepo _user;
    public AuthService(IJwtGenerator jwtGenerator, IUserRepo user)
    {
        _jwtGenerator = jwtGenerator;
        _user = user;
    }

    public AuthResult Login(string userName, string pwd)
    {
        // check user is exit
        if (_user.GetUserByEmail(userName) is not User user)
        {
            throw new Exception("no existing user with such email");
        }
        if (pwd  != "12345")
        {
            throw new Exception("no such user");
        }
        
        // create token fro redirection 
        var token = _jwtGenerator.GenerateToke(user.Id,user.Name);
        
        return  new AuthResult(Guid.NewGuid(), user.Name,user.Email,token);
    }

    public AuthResult Register(string userName, string pwd, string email)
    {
        if (_user.GetUserByEmail(userName) is not null)
        {
            throw new Exception("user already exist");
        }
        var newUser = new User()
        {
            Name = userName,
            Pwd = pwd,
            Email = email,
        };
        _user.AddUser(newUser);
        var token = _jwtGenerator.GenerateToke(newUser.Id,newUser.Email);
        return  new AuthResult(Guid.NewGuid(), newUser.Name,newUser.Email,token);
    }
}