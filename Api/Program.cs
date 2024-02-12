using Api.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();

builder.ConfigureServices();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureApp();

app.Run();