using MikyAuth.Library.Gateway;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/////////////////////////////
builder.Services.AddMikyAuthServer(options =>
{
    // MODIFY PASSWORDS BEFORE YOU RUN!!!
    options.DB_Adress = "127.0.0.1";
    options.DB_Port = 3366;
    options.DB_User = "user";
    options.DB_Password = "password";
    /////////////////////////////
});
/////////////////////////////
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
