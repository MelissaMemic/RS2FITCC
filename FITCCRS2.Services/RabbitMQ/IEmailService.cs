namespace FITCCRS2.Services.RabbitMQ
{
    public interface IEmailService
    {
        public void SendMessage<T>(T message);
    }
}


