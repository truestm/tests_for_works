namespace Biogenom_test.Models.Dto
{
    public record ProductConsumptionDto(
        int ProductId,
        int TimesPerMonth,
        decimal TypicalPortionGrams);
}
