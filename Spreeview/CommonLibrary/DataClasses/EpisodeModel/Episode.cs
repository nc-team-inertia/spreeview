using System.Text.Json.Serialization;

namespace CommonLibrary.DataClasses.EpisodeModel;

public class Episode : IEntity
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Title { get; set; } = "";

    [JsonPropertyName("episode_number")]
	public int EpisodeNumber { get; set; }

    [JsonPropertyName("still_path")]
    public string StillPath { get; set; } = "";
}
