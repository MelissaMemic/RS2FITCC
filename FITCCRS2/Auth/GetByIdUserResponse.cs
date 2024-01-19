namespace FITCCRS2.Auth
{
    public class GetByIdUserResponse : BaseResponse
    {
        public GetByIdUserResponse(Guid correlationId) : base(correlationId)
        {
        }

        public GetByIdUserResponse()
        {
        }

        public Model.User User { get; set; }
    }
}
