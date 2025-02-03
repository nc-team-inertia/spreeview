﻿using AutoMapper;
using CommonLibrary.DataClasses.SeriesModel;

namespace SpreeviewAPI.MappingProfiles
{
	public class SeriesMappingProfile : Profile
	{
		public SeriesMappingProfile()
		{
			CreateMap<SeriesDTO, SeriesGetDTO>()
				.ReverseMap();
		}
	}
}
