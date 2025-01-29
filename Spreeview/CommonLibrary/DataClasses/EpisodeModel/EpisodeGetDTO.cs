namespace CommonLibrary.DataClasses.EpisodeModel
{
    internal class EpisodeGetDTO : IGetDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
    }
}
