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
            CreateMap<BookEntity, FavoriteBookDto>();

            CreateMap<TopicEntity, Topic>();
            CreateMap<TopicEntity, TopicDto>();

            CreateMap<CategoryEntity, Category>();
            CreateMap<CategoryEntity, CategoryDto>();

            CreateMap<FavoriteEntity, Favorite>();
            CreateMap<FavoriteEntity, FavoriteDto>();

            CreateMap<EmotionEntity, Emotion>();
            CreateMap<EmotionEntity, EmotionDto>();

            CreateMap<UserEntity, User>();
            CreateMap<UserEntity, UserDto>();
            CreateMap<UserEntity, UserBookDto>();

            CreateMap<ImpressionEntity, Impression>();
            CreateMap<ImpressionEntity, ImpressionDto>();
            CreateMap<ImpressionEntity, ImpressionUserDto>();
        }
    }
}
