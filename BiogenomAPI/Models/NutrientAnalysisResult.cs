namespace BiogenomAPI.Models
{
    public class NutrientAnalysisResult
    {
        public required Nutrient Nutrient { get; init; }
        public required NutritionalNorm Norm { get; init; }
        public decimal TotalConsumed { get; init; }
        public decimal DailyNorm { get; init; }
    }
}
