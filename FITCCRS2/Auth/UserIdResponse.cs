namespace FITCCRS2.Auth
{
    public class UserIdResponse:BaseResponse
    {
        public UserIdResponse(Guid correlationId) : base(correlationId)
        {
        }

        public UserIdResponse()
        {
        }

        public Model.User User { get; set; }
    }
}
