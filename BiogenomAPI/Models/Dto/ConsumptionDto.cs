namespace BiogenomAPI.Models.Dto
{
    public record ConsumptionDto(
        int ProductId,
        int TimesPerMonth,
        decimal TypicalPortionGrams);
}
