using AutoMapper;
using CommonLibrary.DataClasses.EpisodeModel;

namespace SpreeviewAPI.MappingProfiles
{
	public class EpisodeMappingProfile : Profile
	{
		public EpisodeMappingProfile()
		{
			CreateMap<Episode, EpisodeGetDTO>()
				.ReverseMap();
		}
	}
}
