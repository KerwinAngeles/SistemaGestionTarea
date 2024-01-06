using Capa_Datos;
using Capa_Servicios;
using Capa_Servicios.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Politica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});
builder.Services.AddScoped<TareaObservable>();
builder.Services.AddScoped<IAutentication, AutenticationServices>();
builder.Services.AddScoped<IUsuario, UsuarioServices>();
builder.Services.AddScoped<GestionarUsuario>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Politica");

app.UseAuthorization();

app.MapControllers();

app.Run();
