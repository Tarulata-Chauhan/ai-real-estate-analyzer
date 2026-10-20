namespace AI_RealEstate_Analyzer.Models;

public record PropertyListing(
    string Id,
    string Address,
    string Neighborhood,
    int Bedrooms,
    decimal ListedPrice,
    string RawDescription
);

public record PropertyInsight(
    string PropertyId,
    bool HasFinishedBasement,
    string RoofStatus,
    string RenovationStatus,
    int InvestmentScore
);
