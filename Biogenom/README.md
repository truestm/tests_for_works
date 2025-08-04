Тестовое задание.

[Тех. задание](tz.pdf)

Задача.

Web API проект без Minimal API и top-level statements, используется Microsoft.EntityFrameworkCore и Npgsql.EntityFrameworkCore.PostgreSQL

Пользователь заполняет анкету - возраст, вес, пол, типовой образ жизни (очень подвижный - подвижный ... малоподвижный).

Указывает какие примерно продукты употребляет и как часто (хлеб рыба мясо овощи фрукты) в месяц.

Сервис сопоставляет содержимое элементов (витамины жиры углеводы) в каждом из продуктов с частотой их потребления и нормой 
в зависимости от параметров человека

[BiogenomAPI](BiogenomAPI) - проект сервиса
при первом запуске если указанная база отсутствует она создается и заполняется [начальными данными](BiogenomAPI/Predefines)

[BiogenomAPITests](BiogenomAPITests) - проект с интеграционными тестами для основных сценариев

Дефолтные настройки коннекция для тестового сервера
Host=localhost;Port=5432;Database=biogenom_test;Username=test;Password=test;

Таблицы:

[Nutrients(Id)](BiogenomAPI/Models/Nutrient.cs) - питательные элементы (витамины, белки углеводы и пр.)

[Products(Id)](BiogenomAPI/Models/Product.cs) - продукты содержащие питательные вещества (хлеб, мясо, овощи, рыба и пр.).

[ProductNutrients(NutrientId, ProductId)](BiogenomAPI/Models/ProductNutrient.cs) - содержание питательных веществ в продуктах.

[Users(Id)](BiogenomAPI/Models/User.cs) - пользователи с их параметрами (вес, образ жизни, дата рождения и пр.)

[Consumptions(UserId, ProductId)](BiogenomAPI/Models/Consumption.cs) - примерное потребление продуктов пользователем за период.

[NutritionalNorms(NutrientId, User)](BiogenomAPI/Models/NutritionalNorm.cs) - нормы потребления питательных веществ в зависимости от параметров пользователя.

