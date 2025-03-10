﻿using AutoMapper;
using backend.Abstractions;
using backend.Contracts;
using backend.Models;
using backend.Repositories;

namespace backend.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBookRepository repository;
        private readonly IUserRepository _userRepository;
        private readonly ITopicRepository _topicRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public BooksService(
            IBookRepository bookRepository,
            IUserRepository userRepository,
            ITopicRepository topicRepository,
            ICategoryRepository categoryRepository,
            IFileService fileService,
            IMapper mapper)
        {
            repository = bookRepository;
            _userRepository = userRepository;
            _topicRepository = topicRepository;
            _categoryRepository = categoryRepository;
            _fileService = fileService;
            _mapper = mapper;
        }

        public async Task<List<BookDto>> GetAllBooks(FilterBookDto query)
        {
            var books = await repository.List(query);

            var response = books.Select(b => new BookDto(
                    b.Id, 
                    b.ImagePath,
                    b.FilePath,
                    b.Title,
                    b.Description,
                    b.Price,
                    _mapper.Map<TopicDto>(b.Topic),
                    _mapper.Map<CategoryDto>(b.Category),
                    _mapper.Map<UserDto>(b.User),
                    b.CreatedAt
                ))
                .ToList();

            return response;
        }

        public async Task<List<TopicBooksDto>> GetBooksGroupedByTopic(FilterBookDto query)
        {
            var books = await repository.List(query);
            var groupedBooks = books
                .GroupBy(b => b.Category)
                .Select(g => new TopicBooksDto(
                    g.Key.Id,
                    g.Key.Title,
                    g.Select(b => new BookDto(
                        b.Id,
                        b.ImagePath,
                        b.FilePath,
                        b.Title,
                        b.Description,
                        b.Price,
                        _mapper.Map<TopicDto>(b.Topic),
                        _mapper.Map<CategoryDto>(b.Category),
                        _mapper.Map<UserDto>(b.User),
                        b.CreatedAt)).ToList()
                ))
                .ToList();

            return groupedBooks;
        }

        public async Task<Book> GetBook(Guid id)
        {
            return await repository.GetById(id);
        }

        public async Task<Guid> CreateBook(CreateBookDto dto)
        {
            var topic = await _topicRepository.GetById(dto.Topic);
            var category = await _categoryRepository.GetById(dto.Category);
            var user = await _userRepository.GetById(dto.User);

            if (topic == null || category == null || user == null)
            {
                throw new BadHttpRequestException("Bad request");
            }

            string? imagePath = null;
            string? filePath = null;
             
            if (dto.Image == null || dto.File == null)
            {
                throw new BadHttpRequestException("Bad request");
            }

            imagePath = await _fileService.SaveFileAsync(dto.Image);
            filePath = await _fileService.SaveFileAsync(dto.File);


            var book = Book.Create(
                Guid.NewGuid(),
                imagePath,
                filePath,
                dto.Title,
                dto.Description,
                dto.Price,
                topic,
                category,
                user
            );

            return await repository.Create(book);
        }

        public async Task<Guid> UpdateBook(Guid id, UpdateBookDto book)
        {
            string? imagePath = null;
            string? filePath = null;

            if (book.Image != null)
                imagePath = await _fileService.SaveFileAsync(book.Image);

            if (book.File != null)
                filePath = await _fileService.SaveFileAsync(book.File);

            return await repository.Update(id, book, imagePath, filePath);
        }

        public async Task<Guid> DeleteBook(Guid id)
        {
            return await repository.Delete(id);
        }

    }
}
