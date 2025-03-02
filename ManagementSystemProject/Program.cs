using ManagementSystem.Application;
using ManagementSystem.DAL.SqlServer;
using ManagementSystemProject.Infractructure.Midldewares;
using ManagementSystemProject.Security;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();



var conn = builder.Configuration.GetConnectionString("MyConn");

builder.Services.AddSqlServerServices(conn);

builder.Services.AddApplicationServices();
builder.Services.AddAuthenticationService(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseSwagger();

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseMiddleware<RateLimitMiddleware>(2, TimeSpan.FromMinutes(1));

app.Run();
