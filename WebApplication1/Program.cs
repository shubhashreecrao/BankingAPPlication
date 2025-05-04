using WebApplication1.Repositories;
using WebApplication1.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ✅ Load configuration from appsettings.json
var configuration = builder.Configuration;

// ✅ Add Controllers
builder.Services.AddControllers();

// ✅ Add Swagger & XML Comments
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
});

// ✅ Register your services and repositories (Dependency Injection)
builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddSingleton<IAccountDetailsRepository, AccountDetailsRepository>();
builder.Services.AddScoped<AccountService>();

// ✅ Add JWT Authentication
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["Jwt:Key"])
            )
        };
    });

// ✅ Add Authorization
builder.Services.AddAuthorization();

var app = builder.Build();

// ✅ Enable Swagger
app.UseSwagger();
app.UseSwaggerUI();

// ✅ Use HTTPS
app.UseHttpsRedirection();

// ✅ Add Authentication & Authorization middleware (IMPORTANT ORDER)
app.UseAuthentication();    // 👈 Must come BEFORE UseAuthorization()
app.UseAuthorization();

// ✅ Map controller routes
app.MapControllers();

app.Run();
