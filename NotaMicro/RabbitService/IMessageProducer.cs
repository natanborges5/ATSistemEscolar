namespace NotaMicro.RabbitService
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message);
    }
}
