using AutoMapper;
using backend.Contracts;
using backend.Entities;
using backend.Models;

namespace backend
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookEntity, Book>();
            CreateMap<BookEntity, BookDto>();

            CreateMap<TopicEntity, Topic>();
            CreateMap<TopicEntity, TopicDto>();

            CreateMap<CategoryEntity, Category>();
            CreateMap<CategoryEntity, CategoryDto>();

            CreateMap<UserEntity, User>();
            CreateMap<UserEntity, UserDto>();
        }
    }
}
