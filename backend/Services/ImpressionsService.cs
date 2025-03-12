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
        private readonly IEmotionRepository _emotionRepository;
        private readonly IMapper _mapper;

        public ImpressionsService(
            IImpressionRepository impressionRepository,
            IBookRepository bookRepository,
            IUserRepository userRepository,
            IEmotionRepository emotionRepository,
            IMapper mapper)
        {
            repository = impressionRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            _emotionRepository = emotionRepository;
            _mapper = mapper;
        }

        private ImpressionDto MapToImpressionDto(Impression i)
        {
            return new ImpressionDto(
                i.Id,
                i.Text,
                _mapper.Map<BookDto>(i.Book),
                _mapper.Map<UserBookDto>(i.User),
                _mapper.Map<List<EmotionDto>>(i.Emotions),
                i.CreatedAt
            );
        }

        private ImpressionUserDto MapToImpressionUserDto(Impression i)
        {
            return new ImpressionUserDto(
                i.Id,
                i.Text,
                _mapper.Map<BookDto>(i.Book),
                _mapper.Map<List<EmotionDto>>(i.Emotions),
                i.CreatedAt
            );
        }

        public async Task<List<ImpressionDto>> GetImpressionsByBookId(Guid bookId)
        {
            var impressions = await repository.ListByBookId(bookId);
            return impressions.Select(i => MapToImpressionDto(i)).ToList();
        }

        public async Task<List<ImpressionUserDto>> GetImpressionsByUserId(Guid userId)
        {
            var impressions = await repository.ListByUserId(userId);
            return impressions.Select(i => MapToImpressionUserDto(i)).ToList();
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
            var emotions = await _emotionRepository.GetByIds(dto.Emotions);

            if (book == null || user == null || emotions == null)
                throw new BadHttpRequestException("Bad request");

            var impression = Impression.Create(
                Guid.NewGuid(),
                dto.Text,
                user,
                book,
                emotions
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
