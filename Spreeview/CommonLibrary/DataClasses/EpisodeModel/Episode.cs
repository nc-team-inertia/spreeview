﻿namespace CommonLibrary.DataClasses.EpisodeModel;

public class Episode : IEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
}