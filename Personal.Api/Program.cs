using Personal.Api.Context;
using Personal.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddPersonalConfiguration();

builder.Services.AddPersonalDbContext<PersonalDbContext>(builder.Configuration);
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UsePersonal();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
