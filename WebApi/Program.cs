using WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<SenderService>();
builder.Services.AddHostedService<ReceieverService>();

var app = builder.Build();

app.UseHttpsRedirection();


app.Run();
