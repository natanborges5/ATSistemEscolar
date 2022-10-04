﻿using Microsoft.AspNetCore.Connections;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace NotaMicro.RabbitService
{
    public class RabbitMQProducer : IMessageProducer
    {
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(
                queue: "letterbox",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "", routingKey: "letterbox", body: body);
        }
    }
}
