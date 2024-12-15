﻿using Auction.Domain.Auctions;
using ErrorOr;

namespace Auction.Application.Interfaces;

public interface IAuctionsRepository
{
    Task<List<AuctionEntity>> GetAuctionsAsync(CancellationToken cancellationToken = default);
    Task<AuctionEntity?> GetAuctionByIdAsync(Guid auctionId, CancellationToken cancellationToken = default);
    Task<AuctionEntity?> CreateAuctionAsync(AuctionEntity auctionToCreate, CancellationToken cancellationToken = default);
    Task<AuctionEntity> UpdateAuctionByIdAsync(AuctionEntity updatedAuction, CancellationToken cancellationToken = default);
}