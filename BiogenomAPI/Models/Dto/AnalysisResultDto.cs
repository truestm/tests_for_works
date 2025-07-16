namespace BiogenomAPI.Models.Dto
{
    public class AnalysisResultDto
    {
        public List<NutrientDeviationDto> Deviations { get; set; } = new();
        public string Summary { get; set; } = string.Empty;
    }
}
