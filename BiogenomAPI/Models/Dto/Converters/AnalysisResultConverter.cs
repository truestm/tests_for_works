namespace BiogenomAPI.Models.Dto.Converters
{
    public static class AnalysisResultConverter
    {
        public static NutrientAnalysisResultDto ToDto(this NutrientAnalysisResult db) =>
            new
            (
                db.Nutrient.Id,
                db.Nutrient.Name,
                db.Nutrient.Unit,
                db.Norm.Id,
                db.Norm.Description,
                db.Norm.DailyNorm,
                db.Norm.DailyNormWeight,
                db.TotalConsumed,
                db.DailyNorm
            );

        public static NutrientAnalysisResultDto[] ToDto(this IEnumerable<NutrientAnalysisResult> db) => db.Select(ToDto).ToArray();
    }
}
