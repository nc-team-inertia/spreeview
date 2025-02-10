namespace CommonLibrary.DataClasses.ReviewModel;

public class ReviewUpdateDTO : IUpdateDTO
{
    public int Id { get; set; }
	public string Contents { get; set; }
    public int Rating { get; set; }
}
