using Card.Database.Context;
using Card.Domain.Entities;
using Card.Domain.Entities.CardAggregate;
using Card.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Card.Service.Sync
{
    public static class SyncData
    {
        public static void Sync(IServiceProvider serviceProvider)
        {
            CardContext context = serviceProvider.GetRequiredService<CardContext>();

            context.Cards.Add(new CustomerCard(Guid.Parse("6BF51D86-C0C2-4C91-988F-7CFE1A236587"), 1, 1220233621155660, 522));
            context.Cards.Add(new CustomerCard(Guid.Parse("29FEAC38-64E0-44CA-83FB-E9837AEAE110"), 2, 1220233621155660, 125));
            context.SaveChanges();
        }        
    }
}
