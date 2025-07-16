namespace BiogenomAPI.Models.Dto
{
    public record NutrientDeviationDto(
        int NutrientId,
        decimal ActualAmount,
        decimal RecommendedAmount,
        decimal Deviation,
        string NutrientName,
        NutrientUnit Unit);
}
