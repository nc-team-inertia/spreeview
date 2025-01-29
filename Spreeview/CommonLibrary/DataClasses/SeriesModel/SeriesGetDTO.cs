namespace CommonLibrary.DataClasses.SeriesModel
{
    internal class SeriesGetDTO : IGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
