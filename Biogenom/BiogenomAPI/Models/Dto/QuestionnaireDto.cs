namespace BiogenomAPI.Models.Dto
{
    public record QuestionnaireDto(UserResultDto? Owner, ConsumptionDto[] Consumptions);
}
