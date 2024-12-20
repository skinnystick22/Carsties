﻿using Auction.Domain.Auctions;
using Auction.Domain.Items;
using Bogus;

namespace Auction.Infrastructure.Data;

public static class SeedData
{
    public static List<AuctionEntity> GenerateAuctions()
    {
        Randomizer.Seed = new Random(1_573);

        var auctionFaker = new Faker<AuctionEntity>("en_US")
            .RuleFor(a => a.Id, f => Guid.CreateVersion7())
            .RuleFor(a => a.Status, f => f.PickRandom<Status>())
            .RuleFor(a => a.ReservePrice, f => f.Finance.Random.Decimal(10_000m, 600_000m))
            .RuleFor(a => a.Seller, f => f.Person.UserName)
            .RuleFor(a => a.AuctionEnd, f => DateTime.SpecifyKind(f.Date.Future(5), DateTimeKind.Utc))
            .RuleFor(a => a.ItemEntity, f => new ItemEntity(f.Vehicle.Manufacturer(),
                f.Vehicle.Model(),
                f.Random.Int(1920, 2021),
                f.Commerce.Color(),
                f.Vehicle.Random.Int(1_000, 350_001),
                f.Image.PlaceholderUrl(150, 150)));

        return auctionFaker.Generate(10);
    }
}