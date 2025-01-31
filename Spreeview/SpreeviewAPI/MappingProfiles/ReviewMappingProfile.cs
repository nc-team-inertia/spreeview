using AutoMapper;
using CommonLibrary.DataClasses.Entities;
using CommonLibrary.DataClasses.ReviewModel;

namespace SpreeviewAPI.MappingProfiles
{
    public class ReviewMappingProfile : Profile
    {
        public ReviewMappingProfile()
        {
            CreateMap<Review, CommentGetDTO>()
                .ReverseMap();

            CreateMap<Review, CommentInsertDTO>()
                .ReverseMap();

            CreateMap<Review, CommentUpdateDTO>()
                .ReverseMap();
        }
    }
}
