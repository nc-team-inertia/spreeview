﻿namespace CommonLibrary.DataClasses.EpisodeModel
{
    public class SeasonGetDTO : IGetDTO
    {
		public int Id { get; set; }
		public string Title { get; set; }
		public int EpisodeNumber { get; set; }
	}
}
