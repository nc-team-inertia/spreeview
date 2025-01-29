namespace CommonLibrary.DataClasses.Entities;

public class Review : IEntity
{
    public int Id { get; set; }
    public int EpisodeId { get; set; }
}