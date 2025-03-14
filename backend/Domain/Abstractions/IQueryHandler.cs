﻿using backend.Shared.Core;

namespace backend.Domain.Abstractions
{
    public interface IQueryHandler<TResponse, in TQuery> where TQuery : IQuery
    {
        public Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken = default);
    }

    public interface IQueryHandlerWithResult<TResponse, in TQuery> where TQuery : IQuery
    {
        public Task<Result<TResponse>> Handle(TQuery query, CancellationToken cancellationToken = default);
    }
}
