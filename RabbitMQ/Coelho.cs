using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public class Coelho
{
    void ProducerRabbit(string mensagem)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };

        using var connection = factory.CreateConnection();

        using var channel = connection.CreateModel();

        channel.QueueDeclare(
            queue: "letterbox",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var message = "This is my first Message";

        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish("", "letterbox", null, body);

        Console.WriteLine($"Send message: {message}");
    }
    string ReceiverRabbit()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };

        using var connection = factory.CreateConnection();

        using var channel = connection.CreateModel();

        channel.QueueDeclare(
            queue: "letterbox",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        var nota = "";
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            nota = message;
            Console.WriteLine($"Recieved new message: {message}");
        };

        channel.BasicConsume(queue: "letterbox", autoAck: true, consumer: consumer);
        return nota;
    }
}

