using AutoMapper;
using CommonLibrary.DataClasses.ReviewModel;

namespace SpreeviewAPI.MappingProfiles
{
    public class ReviewMappingProfile : Profile
    {
        public ReviewMappingProfile()
        {
            CreateMap<Review, ReviewGetDTO>()
                .ReverseMap();

            CreateMap<Review, ReviewInsertDTO>()
                .ReverseMap();

            CreateMap<Review, ReviewUpdateDTO>()
                .ReverseMap();
        }
    }
}
