using AutoMapper;
using CommonLibrary.DataClasses.CommentModel;

namespace SpreeviewAPI.MappingProfiles
{
	public class CommentMappingProfile : Profile
	{
		public CommentMappingProfile()
		{
			CreateMap<Comment, CommentGetDTO>()
				.ReverseMap();

			CreateMap<Comment, CommentInsertDTO>()
				.ReverseMap();

			CreateMap<Comment, CommentUpdateDTO>()
				.ReverseMap();
		}
	}
}
