using BuildingBlocks.Domain.SeedWork;
using Ordering.Domain.AggregatesModel.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories;

public class CardRepository
    : ICardRepository
{
    private readonly CardContext _context;

    public IUnitOfWork UnitOfWork => _context;

    public CardRepository(CardContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Card Add(Card order)
    {
        return _context.Orders.Add(order).Entity;

    }

    public async Task<Card> GetAsync(int orderId)
    {
        var order = await _context.Orders.FindAsync(orderId);

        if (order != null)
        {
            await _context.Entry(order)
                .Collection(i => i.OrderItems).LoadAsync();
        }

        return order;   
    }

    public async Task<List<Card>> GetAllAsync(int pageIndex, int pageSize)
    {
        var orders = await _context.Orders
                       .Include(o => o.OrderItems)
                       .OrderBy(o => o.OrderDate)
                       .Skip(pageSize * pageIndex)
                       .Take(pageSize)
                       .ToListAsync();

        return orders;
    }


    public void Update(Card order)
    {
        _context.Entry(order).State = EntityState.Modified;
    }
}
