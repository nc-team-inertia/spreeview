namespace CommonLibrary.DataClasses.SeriesModel;

public class Series : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}