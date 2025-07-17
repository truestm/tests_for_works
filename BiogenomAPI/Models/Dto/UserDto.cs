namespace BiogenomAPI.Models.Dto
{
    public record UserDto(DateOnly BirthDate, decimal Weight, Gender Gender, Lifestyle Lifestyle);
    public record UserResultDto(int? UserId, UserDto? User);
}
