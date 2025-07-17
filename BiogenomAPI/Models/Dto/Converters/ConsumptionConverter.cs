namespace BiogenomAPI.Models.Dto.Converters
{
    public static class ConsumptionConverter
    {
        public static ConsumptionDto ToDto(this Consumption db) => 
            new(db.ProductId, db.TimesPerMonth, db.TypicalPortionGrams);

        public static ConsumptionDto[] ToDto(this IEnumerable<Consumption> db) => db.Select(ToDto).ToArray();

        public static Consumption ToDb(this ConsumptionDto dto, Consumption db)
        {
            db.ProductId = dto.ProductId;
            db.TimesPerMonth = dto.TimesPerMonth;
            db.TypicalPortionGrams = dto.TypicalPortionGrams;
            return db;
        }

        public static Consumption ToDb(this ConsumptionDto dto, int userId) => ToDb(dto, new Consumption() { UserId = userId });
    }
}
