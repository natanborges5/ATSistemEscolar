using NotaMicro.Repository;
using NotaMicro.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<IAtividadeService, AtividadeService>(c =>
         c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:AtividadeAPI"])
    );
builder.Services.AddHttpClient<IDisciplinaService, DisciplinaService>(c =>
         c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:DisciplinaAPI"])
    );
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
