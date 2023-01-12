namespace alidddd.Application.Auth;

public interface IAuthService
{
    AuthResult Login(string userName, string pwd);
    AuthResult Register(string userName, string pwd,string email);
}