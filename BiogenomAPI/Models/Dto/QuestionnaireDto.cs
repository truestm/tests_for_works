namespace BiogenomAPI.Models.Dto
{
    public record QuestionnaireDto(UserDto User, ConsumptionDto[] Consumptions);
}
