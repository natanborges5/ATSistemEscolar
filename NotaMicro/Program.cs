using Newtonsoft.Json;
using NotaMicro.Model;
using NotaMicro.RabbitService;
using NotaMicro.Repository;
using NotaMicro.Service;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

List<string> notaList = new List<string>();
var factory = new ConnectionFactory { HostName = "localhost" };
var connection = factory.CreateConnection();
using var channel = connection.CreateModel();
channel.QueueDeclare(
    queue: "letterbox",
    durable: false,
    exclusive: false,
    autoDelete: false,
    arguments: null);
var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    notaList.Add(message);
    Console.WriteLine(message);
};
channel.BasicConsume(queue: "letterbox", autoAck: true, consumer: consumer);
Console.WriteLine(notaList);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<IAtividadeService, AtividadeService>(c =>
         c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:AtividadeAPI"])
    );
builder.Services.AddHttpClient<IDisciplinaService, DisciplinaService>(c =>
         c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:DisciplinaAPI"])
    );
builder.Services.AddScoped<IMessageProducer, RabbitMQProducer>();
builder.Services.AddScoped<INotaRepository, NotaRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
