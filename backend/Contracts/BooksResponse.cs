﻿using backend.Models;

namespace backend.Contracts
{
    public record BooksResponse(
        int Id,
        string Title,
        string Description,
        decimal Price,
        Category Category,
        User User
    );
}
