using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace BiogenomAPI
{
    public static class DbImporter
    {
        public static void ImportJson<TEntity>(this DbSet<TEntity> table, string filename) where TEntity : class
        {
            if (!table.Any())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                        Converters = { new JsonStringEnumConverter() }
                    };

                    var values = JsonSerializer.Deserialize<List<TEntity>>(stream, options);
                    if (values != null)
                        table.AddRange(values);
                }
            }
        }
    }
}
