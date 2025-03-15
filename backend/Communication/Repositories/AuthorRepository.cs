using AutoMapper;
using backend.Domain;
using backend.Domain.Abstractions;
using backend.Domain.Entities;
using backend.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Communication.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AuthorRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Author>> List()
        {
            var authorEntities = await _context.Authors.AsNoTracking().ToListAsync();

            var authors = authorEntities.Select(a => Author.Create(
                a.Id,
                a.FullName,
                a.About,
                a.AvatarPath))
                .ToList();

            return authors;
        }

        public async Task<Author> GetById(Guid id)
        {
            var a = await _context.Authors
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id) ?? throw new Exception();

            return Author.Create(
                a.Id,
                a.FullName,
                a.About,
                a.AvatarPath
            );
        }

        public async Task<Guid> Create(Author author)
        {
            var authorEntity = new AuthorEntity
            {
                Id = author.Id,
                FullName = author.FullName,
                About = author.About,
                AvatarPath = author.AvatarPath
            };

            await _context.Authors.AddAsync(authorEntity);
            await _context.SaveChangesAsync();

            return authorEntity.Id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Authors.Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
