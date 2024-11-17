﻿using BuildingBlocks.Domain.SeedWork;
using Card.Domain.AggregatesModel.CardAggregate;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories;

public class CardRepository : ICardRepository
{
    private readonly CardContext _context;

    public IUnitOfWork UnitOfWork => _context;

    public CardRepository(CardContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Card.Domain.AggregatesModel.CardAggregate.Card Add(Card.Domain.AggregatesModel.CardAggregate.Card order)
    {
        return _context.Cards.Add(order).Entity;
    }

    public async Task<Card.Domain.AggregatesModel.CardAggregate.Card> GetBySerialNumberAsync(string id)
    {
        var order = _context.Cards.FirstOrDefault(p => p.SerialNumber == id);

        return order;
    }
    public async Task<Card.Domain.AggregatesModel.CardAggregate.Card> GetByAccountNumberAsync(string id)
    {
        var order = _context.Cards.FirstOrDefault(p => p.AccountNumber == id);

        return order;
    }

    public async Task<Card.Domain.AggregatesModel.CardAggregate.Card> GetByIdAsync(string id)
    {
        var order = _context.Cards.FirstOrDefault(p => p.Id == id);

        return order;
    }

    public async Task<string> Delete(string id)
    {
        var toBeDeleted = await _context.Cards.FirstOrDefaultAsync(p => p.Id == id);
        var result = _context.Cards.Remove(toBeDeleted);

        return result.Entity.Id;
    }
}