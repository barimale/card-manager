using BuildingBlocks.Domain.Request;
using BuildingBlocks.Domain.Response;
using BuildingBlocks.Domain.SeedWork;
using System;

namespace Ordering.Infrastructure.Repositories;

public class RequestRepository
    : IRequestRepository
{
    private readonly CardContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public RequestRepository(CardContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Request Add(Request request)
    {
        if (request.IsTransient())
        {
            return _context.Requests
                .Add(request)
                .Entity;
        }

        return request;
    }
}
