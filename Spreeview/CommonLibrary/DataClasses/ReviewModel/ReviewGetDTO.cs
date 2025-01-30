namespace CommonLibrary.DataClasses.ReviewModel
{
    public class ReviewGetDTO : IGetDTO
    {
        public int Id { get; set; }
        public int EpisodeId { get; set; }
    }
}
