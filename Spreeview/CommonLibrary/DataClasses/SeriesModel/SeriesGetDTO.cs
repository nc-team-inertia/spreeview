namespace CommonLibrary.DataClasses.SeriesModel
{
    public class SeriesGetDTO : IGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
