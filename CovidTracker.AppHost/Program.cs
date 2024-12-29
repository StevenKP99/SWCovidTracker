var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.CovidTracker_ApiService>("apiservice")
    .WithExternalHttpEndpoints();

builder.AddProject<Projects.CovidTracker_Web>("webfrontend")
    .WithExternalHttpEndpoints();

builder.Build().Run();
