using AFishka.Persistence;
using AFishka.Application;
using AFishkaAPI.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

IConfiguration config = builder.Configuration;

//Add services to the container.
builder.Services.AddAuthentication().AddJwtBearer(options =>
{
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ValidIssuer = config["Jwt:Issuer"],
		//ValidAudiences = JsonSerializer.Deserialize<IEnumerable<string>>(config["Jwt:Audience"]),
		ValidAudiences = new string[] { "User", "AFishkaAPI" },
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"])),
	};
    options.Events = new JwtBearerEvents()
    {
        OnChallenge = context =>
        {
			Console.WriteLine(context.ErrorDescription);
			return context.Response.WriteAsJsonAsync(context.ErrorDescription);
        }
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddPersistence(config);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
	try
	{
		var context = serviceProvider.GetRequiredService<EventsDbContext>();
		DbInitializer.Initialize(context);
	}
	catch (Exception exception)
	{

	}
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
