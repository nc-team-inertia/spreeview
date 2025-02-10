using System.Text.Json;
using System.Text.Json.Serialization;
using CommonLibrary.DataClasses.SeasonModel;

namespace CommonLibrary.DataClasses.SeriesModel;

public class Series : IEntity
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("first_air_date")]
    [JsonConverter(typeof(NullableDateOnlyConverter))]
    public DateOnly? ReleaseDate { get; set; }

    [JsonPropertyName("overview")]
    public string Overview { get; set; }

    [JsonPropertyName("backdrop_path")]
    public string BannerPath { get; set; }

    [JsonPropertyName("cover_path")]
    public string CoverPath { get; set; }

    [JsonPropertyName("poster_path")]
    public string PosterPath { get; set; }

    public List<Season> Seasons { get; set; }
}

public class NullableDateOnlyConverter : JsonConverter<DateOnly?>
{
    public override DateOnly? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (DateOnly.TryParse(reader.GetString(), out DateOnly validDate))
            return validDate;

        return null;
    }

    public override void Write(Utf8JsonWriter writer, DateOnly? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
            writer.WriteStringValue(value.Value.ToString("yyyy-MM-dd"));
        else
            writer.WriteNullValue();
    }
}
