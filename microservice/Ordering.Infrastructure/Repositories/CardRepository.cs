﻿using BuildingBlocks.Domain.SeedWork;
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
        return _context.Cards.Add(order).Entity;
    }

    public async Task<Card> GetBySerialNumberAsync(string id)
    {
        var order = _context.Cards.FirstOrDefault(p => p.SerialNumber == id);

        return order;
    }
    public async Task<Card> GetByAccountNumberAsync(string id)
    {
        var order = _context.Cards.FirstOrDefault(p => p.AccountNumber == id);

        return order;
    }

    public async Task<Card> GetByIdAsync(string id)
    {
        var order = _context.Cards.FirstOrDefault(p => p.Id == id);

        return order;
    }

    public async Task<List<Card>> GetAllAsync(int pageIndex, int pageSize)
    {
        var orders = await _context.Cards
                       .ToListAsync();

        return orders;
    }
}