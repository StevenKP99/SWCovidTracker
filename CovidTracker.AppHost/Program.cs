using Microsoft.Extensions.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var redisCache = builder.AddRedis("rediscache")
    .WithRedisInsight();

if(builder.Environment.IsDevelopment())
{
    //Used for testing
    var apiService = builder.AddProject<Projects.CovidTracker_ApiService>("apiservice")
        .WithExternalHttpEndpoints()
        .WithReference(redisCache)
        .WaitFor(redisCache);
}


builder.AddProject<Projects.CovidTracker_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(redisCache)
    .WaitFor(redisCache);

builder.Build().Run();
