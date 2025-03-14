using AutoMapper;
using backend.Communication.Contracts;
using backend.Domain.Abstractions;
using backend.Domain.Models;

namespace backend.Application.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBookRepository repository;
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public BooksService(
            IBookRepository bookRepository,
            IUserRepository userRepository,
            ICategoryRepository categoryRepository,
            IFavoriteRepository favoriteRepository,
            IFileService fileService,
            IMapper mapper)
        {
            repository = bookRepository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            _favoriteRepository = favoriteRepository;
            _fileService = fileService;
            _mapper = mapper;
        }

        private async Task<HashSet<Guid>> GetFavoriteIds(Guid? userId)
        {
            return userId == null
                ? new HashSet<Guid>()
                : new HashSet<Guid>(await _favoriteRepository.ListIdByUserId(userId));
        }

        private BookDto MapToBookDto(Book b, HashSet<Guid> favoriteIds)
        {
            return new BookDto(
                b.Id,
                b.ImagePath,
                b.FilePath,
                b.Title,
                b.Description,
                b.Publisher,
                b.Holder,
                b.Translator,
                b.Age,
                b.Pages,
                _mapper.Map<List<CategoryDto>>(b.Categories),
                _mapper.Map<UserBookDto>(b.User),
                b.CreatedAt,
                favoriteIds.Contains(b.Id)
            );
        }

        public async Task<List<BookDto>> GetAllBooks(FilterBookDto query)
        {
            var favoriteIds = await GetFavoriteIds(query.User);
            var books = await repository.List(query);
            return books.Select(b => MapToBookDto(b, favoriteIds)).ToList();
        }

        public async Task<List<CategoryBooksDto>> GetBooksGroupedByCategory(FilterBookDto query)
        {
            var favoriteIds = await GetFavoriteIds(query.User);
            var books = await repository.List(query);

            var groupedBooks = new Dictionary<Guid, CategoryBooksDto>();

            foreach (var book in books)
            {
                foreach (var category in book.Categories)
                {
                    if (!groupedBooks.ContainsKey(category.Id))
                    {
                        groupedBooks[category.Id] = new CategoryBooksDto(
                            category.Id,
                            category.Title,
                            new List<BookDto>()
                        );
                    }

                    groupedBooks[category.Id].Books.Add(MapToBookDto(book, favoriteIds));
                }
            }

            return groupedBooks.Values.ToList();
        }

        public async Task<List<TopicBooksDto>> GetBooksGroupedByTopic(FilterBookDto query)
        {
            var groupedBooks = await repository.List(query);

            return _mapper.Map<List<TopicBooksDto>>(groupedBooks);
        }

        public async Task<BookDto> GetBook(Guid id)
        {
            var book = await repository.GetById(id);
            return _mapper.Map<BookDto>(book);
        }

        private async Task<(string imagePath, string filePath)> SaveFiles(CreateBookDto dto)
        {
            if (dto.Image == null || dto.File == null)
                throw new BadHttpRequestException("Bad request");

            return (
                await _fileService.SaveFileAsync(dto.Image),
                await _fileService.SaveFileAsync(dto.File)
            );
        }

        public async Task<Guid> CreateBook(CreateBookDto dto)
        {
            var categories = await _categoryRepository.GetByIds(dto.Categories);
            var user = await _userRepository.GetById(dto.User);

            if (categories == null)
                throw new BadHttpRequestException("Bad request");

            if (dto.Image == null || dto.File == null)
                throw new BadHttpRequestException("Bad request");

            var (imagePath, filePath) = await SaveFiles(dto);

            var book = Book.Create(
                Guid.NewGuid(),
                imagePath,
                filePath,
                dto.Title,
                dto.Description,
                dto.Publisher,
                dto.Age,
                dto.Pages,
                user,
                categories,
                dto.Holder,
                dto.Translator
            );

            return await repository.Create(book);
        }

        public async Task<Guid> UpdateBook(Guid id, UpdateBookDto book)
        {
            string? imagePath = book.Image != null ? await _fileService.SaveFileAsync(book.Image) : null;
            string? filePath = book.File != null ? await _fileService.SaveFileAsync(book.File) : null;

            return await repository.Update(id, book, imagePath, filePath);
        }

        public async Task<Guid> DeleteBook(Guid id)
        {
            return await repository.Delete(id);
        }

    }
}
