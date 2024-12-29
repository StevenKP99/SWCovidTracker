using Microsoft.Extensions.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

if(builder.Environment.IsDevelopment())
{
    //Used for testing
    var apiService = builder.AddProject<Projects.CovidTracker_ApiService>("apiservice")
    .WithExternalHttpEndpoints();
}


builder.AddProject<Projects.CovidTracker_Web>("webfrontend")
    .WithExternalHttpEndpoints();

builder.Build().Run();
