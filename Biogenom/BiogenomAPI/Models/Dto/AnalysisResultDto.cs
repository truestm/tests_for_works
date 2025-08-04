namespace BiogenomAPI.Models.Dto
{
    public record AnalysisResultDto(
        UserResultDto Owner, 
        NutrientAnalysisResultDto[] Deviations);
}
