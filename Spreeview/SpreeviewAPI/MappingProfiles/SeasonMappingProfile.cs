using AutoMapper;
using CommonLibrary.DataClasses.SeasonModel;

namespace SpreeviewAPI.MappingProfiles
{
	public class SeasonMappingProfile : Profile
	{
		public SeasonMappingProfile()
		{
			CreateMap<Season, SeasonGetDTO>()
				.ReverseMap();
		}
	}
}
