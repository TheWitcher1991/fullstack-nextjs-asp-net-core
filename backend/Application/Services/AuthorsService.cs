using AutoMapper;
using backend.Communication.Contracts;
using backend.Domain.Abstractions;
using backend.Domain.Mappers;

namespace backend.Application.Services
{
    public class AuthorsService : IAuthorsService
    {
        private readonly IAuthorRepository repository;
        private readonly IMapper _mapper;

        public AuthorsService(
            IAuthorRepository authorRepository,
            IMapper mapper)
        {
            repository = authorRepository;
            _mapper = mapper;
        }

        public async Task<List<AuthorDto>> GetAllAuthors()
        {
            var authors = await repository.List();
            return authors.Select(a => AuthorMapper.ToAuthorDto(a)).ToList();
        }

        public async Task<AuthorDto> GetAuthor(Guid id)
        {
            var author = await repository.GetById(id);

            return _mapper.Map<AuthorDto>(author);
        }
    }
}
