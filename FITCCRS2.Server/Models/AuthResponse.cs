namespace FITCCRS2.Server.Models
{
    public class AuthResponse
    {
        public bool Result { get; set; }
        public string Token { get; set; } 
        public string Username { get; set; } 
        public bool IsLockedOut { get; set; } 
        public bool IsNotAllowed { get; set; } 
        public bool RequiresTwoFactor { get; set; }
    }
}
