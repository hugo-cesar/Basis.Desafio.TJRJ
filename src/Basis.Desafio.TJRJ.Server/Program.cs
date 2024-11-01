using Asp.Versioning;
using Basis.Desafio.TJRJ.Api;
using Basis.Desafio.TJRJ.Api.Configurations;
using Basis.Desafio.TJRJ.Domain;
using Basis.Desafio.TJRJ.Domain.Features.Authors;
using Basis.Desafio.TJRJ.Domain.Features.Books;
using Basis.Desafio.TJRJ.Domain.Features.Subjects;
using Basis.Desafio.TJRJ.Infra.Data.Data.Database.Context;
using Basis.Desafio.TJRJ.Infra.Data.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var defaultConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.ConfigureMediatr();
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(defaultConnection));
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IUnitOfWork>(c => c.GetRequiredService<ApplicationDbContext>());
IoCConfig.ConfigureMigrations(defaultConnection);

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.UseErrorMiddleware();

app.Run();