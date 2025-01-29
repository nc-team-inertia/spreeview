namespace CommonLibrary.DataClasses.ReviewModel
{
    internal class ReviewGetDTO : IGetDTO
    {
        public int Id { get; set; }
        public int EpisodeId { get; set; }
    }
}
