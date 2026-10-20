using AI_RealEstate_Analyzer.Models;

namespace AI_RealEstate_Analyzer.Services;

public class ListingParserService
{
    // Simulates an LLM parsing unstructured text into structured JSON
    public PropertyInsight ParseListing(PropertyListing listing)
    {
        var text = listing.RawDescription.ToLower();
        
        bool hasBasement = text.Contains("finished basement") || text.Contains("lower level suite");
        string roof = text.Contains("new roof") ? "New" : "Unknown";
        string renovation = text.Contains("fully renovated") || text.Contains("updated kitchen") ? "High" : "Standard";
        
        // Simple custom scoring logic
        int score = 50;
        if (hasBasement) score += 20;
        if (roof == "New") score += 15;
        if (renovation == "High") score += 15;
        if (listing.ListedPrice < 450000) score += 10; // Bonus for good price in Frederick market

        return new PropertyInsight(listing.Id, hasBasement, roof, renovation, score);
    }
}
