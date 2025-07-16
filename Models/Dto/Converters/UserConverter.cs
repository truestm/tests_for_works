namespace Biogenom_test.Models.Dto.Converters
{
    public static class UserConverter
    {
        public static UserDto ToDto(this User db) => 
            new UserDto(db.BirthDate, db.Weight, db.Gender, db.Lifestyle);

        public static User ToDb(this UserDto dto, User db)
        {
            db.BirthDate = dto.BirthDate;
            db.Weight = dto.Weight;
            db.Gender = dto.Gender;
            db.Lifestyle = dto.Lifestyle;
            return db;
        }

        public static User ToDb(this UserDto dto) => ToDb(dto, new User());
    }
}
