namespace alidddd.Infra.Auth;

public class JwtSettings
{
    public string Secret { get; set; }
    public string Issuer { get; set; }
    public string Audince { get; set; }
    public int Expires { get; set; }
}