using CoreAccess.DataEnvironment.Extensions;
using CoreAccess.Equipment.Extensions;
using CoreAccess.DataEnvironment.Processors;
using FastEndpoints;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();
builder.Services.AddDataEnvironment();
builder.Services.AddEquipment();

var app = builder.Build();
app.UseFastEndpoints(c => c.Endpoints.Configurator = ep => ep.PreProcessors(Order.Before, new TenantConnectionStringLoader()));

app.Run();