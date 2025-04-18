var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.ToDo_ApiService>("apiservice");

builder.AddProject<Projects.ToDo_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
