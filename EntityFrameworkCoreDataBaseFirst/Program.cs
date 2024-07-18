using BussinessLogicLayer.Interface;
using BussinessLogicLayer.Service;
//using EntityFrameworkCoreDataBaseFirst.Handlers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Interface;
using RepositoryLayer.Repository;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container;
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options=>
    {
        options.TokenValidationParameters = new TokenValidationParameters { 
            ValidateIssuer = true,//valideates the server
            ValidateAudience = true,//validates the user
            ValidateLifetime = true,//validatwe the key is vali or within the expiering time
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
builder.Services.AddControllers();
// now our method/program knows it's our authentication
//builder.Services.AddAuthentication("BasicAuthenticationHandler")
 //   .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthenticationHandler",null);//we need to pass the class name
builder.Services.AddScoped<DbContext, UserContext>();
builder.Services.AddTransient<IUserBLL, UserBLL>();
builder.Services.AddTransient<IUserDAL, UserDAL>();
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
app.UseAuthentication();
app.UseHttpsRedirection();
//1.basic authentication
//app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
