using DisciplinaMicro.Repository;
using DisciplinaMicro.Service.AtividadeService;
using DisciplinaMicro.Service.PessoaService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<IAtividadeService, AtividadeService>(c =>
         c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:AtividadeAPI"])
    );
builder.Services.AddHttpClient<IAlunoService, AlunoService>(c =>
         c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:AlunoAPI"])
    );
builder.Services.AddHttpClient<IProfessorService, ProfessorService>(c =>
         c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:AlunoAPI"])
    );
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
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
