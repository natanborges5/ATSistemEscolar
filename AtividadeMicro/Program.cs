using AtividadeMicro.Service.DisciplinaService;
using AtividadeMicro.Service.NotaService;
using TP3Micro.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<IDisciplinaService, DisciplinaService>(c =>
         c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:DisciplinaAPI"])
    );
builder.Services.AddHttpClient<INotaService, NotaService>(c =>
         c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:NotaAPI"])
    );
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAtividadeRepository, AtividadeRepository>();


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
