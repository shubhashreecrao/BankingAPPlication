using WebApplication1.Repositories;
using WebApplication1.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// ✅ Swagger Services with XML Comments
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
});

// ✅ Register DI dependencies
builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddSingleton<IAccountDetailsRepository, AccountDetailsRepository>();
builder.Services.AddScoped<AccountService>();

var app = builder.Build();

// ✅ Enable Swagger Middleware
app.UseSwagger();
app.UseSwaggerUI();

// ✅ Middleware pipeline
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
