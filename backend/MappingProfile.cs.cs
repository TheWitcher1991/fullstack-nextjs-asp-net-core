using AutoMapper;
using backend.Entities;
using backend.Models;

namespace backend
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookEntity, Book>();
            CreateMap<TopicEntity, Topic>();
            CreateMap<CategoryEntity, Category>();
            CreateMap<UserEntity, User>();
        }
    }
}
