namespace FITCCRS2.Auth
{
    public class AuthRequest : BaseRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
