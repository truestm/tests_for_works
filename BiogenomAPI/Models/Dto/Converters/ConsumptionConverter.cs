namespace BiogenomAPI.Models.Dto.Converters
{
    public static class ConsumptionConverter
    {
        public static ConsumptionDto ToDto(this ConsumptionDto db) => 
            new(db.ProductId, db.TimesPerMonth, db.TypicalPortionGrams);

        public static Consumption ToDb(this ConsumptionDto dto, Consumption db)
        {
            db.ProductId = dto.ProductId;
            db.TimesPerMonth = dto.TimesPerMonth;
            db.TypicalPortionGrams = dto.TypicalPortionGrams;
            return db;
        }

        public static Consumption ToDb(this ConsumptionDto dto) => ToDb(dto, new Consumption());
    }
}
