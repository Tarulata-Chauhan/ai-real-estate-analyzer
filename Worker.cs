using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AI_RealEstate_Analyzer.Models;
using AI_RealEstate_Analyzer.Services;

namespace AI_RealEstate_Analyzer;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly ListingParserService _parserService;

    // Hardcoded mock queue simulating market data for Frederick, MD
    private readonly List<PropertyListing> _mockQueue = new()
    {
        new("PRP-001", "101 Major Smith Lane", "Major Smith Lane", 4, 420000, 
            "Beautiful 4 bed home in quiet neighborhood. Fully renovated with updated kitchen and a new roof installed in 2025. Unfinished basement offers storage."),
        new("PRP-002", "88 Notting Hill Dr", "Notting Hill", 3, 460000, 
            "Charming 3 bedroom property. Features a fully finished basement perfect for entertaining. Original roof. Needs some cosmetic updates."),
        new("PRP-003", "42 Historic St", "Downtown Frederick", 4, 510000, 
            "Stunning historic property! 4 bedrooms, updated kitchen, new roof, and a stunning finished lower level suite.")
    };

    public Worker(ILogger<Worker> logger, ListingParserService parserService)
    {
        _logger = logger;
        _parserService = parserService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Real Estate Market Analyzer Started.");
        _logger.LogInformation("Target: 3-4 Bedroom Homes in Frederick, MD");
        _logger.LogInformation("--------------------------------------------------");

        int index = 0;

        while (!stoppingToken.IsCancellationRequested && index < _mockQueue.Count)
        {
            var listing = _mockQueue[index];
            _logger.LogInformation($"[RECEIVED] Parsing listing: {listing.Address} ({listing.Neighborhood})");

            // Process the listing through the simulated AI parser
            var insight = _parserService.ParseListing(listing);

            // Log the extracted structured data
            _logger.LogInformation($"[EXTRACTED] Finished Basement: {insight.HasFinishedBasement}");
            _logger.LogInformation($"[EXTRACTED] Roof Status: {insight.RoofStatus}");
            _logger.LogInformation($"[EXTRACTED] Renovation Level: {insight.RenovationStatus}");
            _logger.LogWarning($"[SCORED] Final Investment Score: {insight.InvestmentScore}/100");
            _logger.LogInformation("--------------------------------------------------");

            index++;
            await Task.Delay(3000, stoppingToken); // Simulate processing time
        }

        _logger.LogInformation("All current market listings processed. Shutting down.");
        Environment.Exit(0);
    }
}
