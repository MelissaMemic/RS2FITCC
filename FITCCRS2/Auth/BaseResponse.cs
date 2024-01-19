namespace FITCCRS2.Auth
{
    public class BaseResponse:BaseMessage
    {
        public BaseResponse(Guid correlationId)
        {
            _correlationId = correlationId;
        }

        public BaseResponse()
        {
        }
    }
}
