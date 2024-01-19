namespace FITCCRS2.Auth
{
    public class AuthResponse:BaseResponse
    {
        public AuthResponse(Guid correlationId) : base(correlationId)
        {
        }

        public AuthResponse()
        {
        }
        public bool Result { get; set; } 
        public string Token { get; set; }
        public string Username { get; set; } 
        public bool IsLockedOut { get; set; }
        public bool IsNotAllowed { get; set; }
        public bool RequiresTwoFactor { get; set; }
    }
}
