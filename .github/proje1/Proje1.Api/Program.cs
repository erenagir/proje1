using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Proje1.Api.Filters;
using Proje1.Aplication.AutoMapper;
using Proje1.Aplication.Models.RequestModels.Company;
using Proje1.Aplication.Services.Abstraction;
using Proje1.Aplication.Services.Implementation;
using Proje1.Aplication.Validators.Company;
using Proje1.Domain.Repositories;
using Proje1.Domain.Services.Abstraction;
using Proje1.Domain.Services.Implementation;
using Proje1.Domain.UWork;
using Proje1.Persistence.Context;
using Proje1.Persistence.Repository;
using Proje1.Persistence.UWork;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new ExceptionHandlerFilter());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "JwtTokenWithIdentity", Version = "v1", Description = "JwtTokenWithIdentity test app" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
});

//unitwork
builder.Services.AddScoped<IUWork, UWork>();



//repository
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//mapper
builder.Services.AddAutoMapper(typeof(DomainToDto), typeof(ViewModelToDomain));
//service

builder.Services.AddScoped<ILoggedUserService, LoggedUserService>();
builder.Services.AddScoped<IProductSevice, ProductService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IRequestFormService,RequestFromService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IInvoiceService , InvoýceService>();
builder.Services.AddScoped<IOfferService, OfferService>();




//db adresleme
builder.Services.AddDbContext<ProjeContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Proje1"));
});

//validator
builder.Services.AddValidatorsFromAssemblyContaining(typeof(CreateDepartmentValidator));

builder.Services.AddHttpContextAccessor();


builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.IncludeErrorDetails = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"], // Tokený oluþturan tarafýn adresi
            ValidAudience = builder.Configuration["Jwt:Audiance"], // Tokenýn kullanýlacaðý hedef adres
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SigningKey"])) // Gizli anahtar
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
