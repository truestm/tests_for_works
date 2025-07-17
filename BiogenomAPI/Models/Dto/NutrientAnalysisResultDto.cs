namespace BiogenomAPI.Models.Dto
{
    public record NutrientAnalysisResultDto(
        int NutrientId,
        string NutrientName,
        NutrientUnit Unit,        
        int NormId,
        string? NormDescription,
        decimal? DailyNorm,
        decimal? DailyNormWeight,
        decimal ActualAmount,
        decimal RecommendedAmount);
}
