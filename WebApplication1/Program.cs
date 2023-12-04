using Carter;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/error");
}

app.MapCarter();

app.Run();