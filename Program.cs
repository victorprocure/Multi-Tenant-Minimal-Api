using CoreAccess.DataEnvironment.Extensions;
using CoreAccess.Equipment.Extensions;
using FastEndpoints;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();
builder.Services.AddDataEnvironment();
builder.Services.AddEquipment();

var app = builder.Build();
app.UseFastEndpoints();

app.Run();