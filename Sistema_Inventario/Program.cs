using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Sistema_Inventario.Context;
using Sistema_Inventario.Endpoints;
using Sistema_Inventario.Repositories;
using Sistema_Inventario.Repositories.Interfaces;
using Sistema_Inventario.Settings;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(o =>{
    o.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<IRol, RolRepository>();

builder.Services.AddScoped<ICategoria, CategoriaRepository>();

builder.Services.AddScoped<IProducto, ProductoRepository>();

builder.Services.AddScoped<IProveedor, ProveedorRepository>();

builder.Services.AddScoped<ITransaccion, TransaccionRepository>();

builder.Services.AddScoped<IUsuario, UsuarioRepository>();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidIssuer = builder.Configuration.GetSection("TokenSetting").GetValue<string>("Issuer"),
            ValidateIssuer = true,
            ValidAudience = builder.Configuration.GetSection("TokenSetting").GetValue<string>("Audience"),
            ValidateAudience = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("TokenSetting").GetValue<string>("Key"))),
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
        };
    });



builder.Services.Configure<TokenSetting>(builder.Configuration.GetSection("TokenSetting"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseEndpoints();
app.Run();
