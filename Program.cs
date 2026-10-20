using AI_RealEstate_Analyzer;
using AI_RealEstate_Analyzer.Services;

var builder = Host.CreateApplicationBuilder(args);

// Register the mock AI parsing service
builder.Services.AddSingleton<ListingParserService>();

// Register the background worker
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
