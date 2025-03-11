using AutoMapper;
using backend.Abstractions;
using backend.Contracts;
using backend.Models;
using backend.Repositories;

namespace backend.Services
{
    public class ImpressionsService : IImpressionsService
    {
        private readonly IImpressionRepository repository;
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ImpressionsService(
            IImpressionRepository impressionRepository,
            IBookRepository bookRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            repository = impressionRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        private ImpressionDto MapToImpressionDto(Impression i)
        {
            return new ImpressionDto(
                i.Id,
                i.Text,
                i.IsAdvise,
                i.IsNoAsdvise,
                i.IsToTearss,
                i.IsNice,
                i.IsBoring,
                i.IsScary,
                i.IsWisely,
                i.IsUnclear,
                _mapper.Map<UserBookDto>(i.User),
                i.CreatedAt
            );
        }

        public async Task<List<ImpressionDto>> GetImpressionsByBookId(Guid bookId)
        {
            var impressions = await repository.ListByBookId(bookId);
            return impressions.Select(i => MapToImpressionDto(i)).ToList();
        }

        public async Task<List<ImpressionDto>> GetImpressionsByUserId(Guid userId)
        {
            var impressions = await repository.ListByUserId(userId);
            return impressions.Select(i => MapToImpressionDto(i)).ToList();
        }

        public async Task<ImpressionDto> GetImpression(Guid id)
        {
            var impression = await repository.GetById(id);
            return _mapper.Map<ImpressionDto>(impression);
        }

        public async Task<Guid> CreateImpression(CreateImpressionDto dto)
        {
            var book = await _bookRepository.GetById(dto.Book);
            var user = await _userRepository.GetById(dto.User);

            if (book == null || user == null)
                throw new BadHttpRequestException("Bad request");

            var impression = Impression.Create(
                Guid.NewGuid(),
                dto.Text,
                dto.IsAdvise,
                dto.IsNoAsdvise,
                dto.IsToTearss,
                dto.IsNice,
                dto.IsBoring,
                dto.IsScary,
                dto.IsWisely,
                dto.IsUnclear,
                user,
                book
            );

            return await repository.Create(impression);
        }

        public async Task<Guid> UpdateImpression(Guid id, UpdateImpressionDto impression)
        {
            return await repository.Update(id, impression);
        }

        public async Task<Guid> DeleteImpression(Guid id)
        {
            return await repository.Delete(id);
        }
    }
}
