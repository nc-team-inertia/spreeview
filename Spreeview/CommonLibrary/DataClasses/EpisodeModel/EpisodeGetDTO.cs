namespace CommonLibrary.DataClasses.EpisodeModel;

public class EpisodeGetDTO : IGetDTO
{
	public int Id { get; set; }
	public string Title { get; set; }
	public int EpisodeNumber { get; set; }
    public string StillPath { get; set; }
	public string Overview { get; set; }
	public int? Runtime { get; set; }
}
