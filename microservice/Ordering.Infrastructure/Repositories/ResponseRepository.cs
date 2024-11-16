using BuildingBlocks.Domain.Response;
using BuildingBlocks.Domain.SeedWork;
using System;

namespace Ordering.Infrastructure.Repositories;

public class ResponseRepository
    : IResponseRepository
{
    private readonly CardContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public ResponseRepository(CardContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Response Add(Response response)
    {
        if (response.IsTransient())
        {
            return _context.Responses
                .Add(response)
                .Entity;
        }

        return response;
    }
}
