using AutoMapper;
using backend.Communication.Contracts;
using backend.Domain.Entities;
using backend.Domain.Models;

namespace backend.Domain
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
