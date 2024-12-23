﻿using Carsties.Core;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using Search.Application.Interfaces;
using Search.Domain.Items;
using Search.Domain.Searches;

namespace Search.Infrastructure.Searches;

public sealed class SearchRepository : ISearchRepository
{
    private readonly IAsyncDocumentSession _documentSession;

    public SearchRepository(IAsyncDocumentSession documentSession)
    {
        _documentSession = documentSession;
    }

    public async Task<PaginatedResponse<List<Item>>> SearchItemsAsync(AuctionSearch auctionSearch, CancellationToken cancellationToken = default)
    {
        var auctions = _documentSession.Query<Domain.Auctions.Auction>()
            .Statistics(out var statistics);

        if (!string.IsNullOrWhiteSpace(auctionSearch.Seller))
        {
            var seller = auctionSearch.Seller;
            auctions = auctions.Search(a => a.Seller, seller, options: SearchOptions.Or);
        }

        if (!string.IsNullOrWhiteSpace(auctionSearch.Winner))
        {
            var winner = auctionSearch.Winner;
            auctions = auctions.Search(a => a.Winner, auctionSearch.Winner, options: SearchOptions.Or);
        }

        if (!string.IsNullOrWhiteSpace(auctionSearch.SearchTerm))
        {
            var searchTerm = auctionSearch.SearchTerm;
            auctions = auctions
                .Search(a => a.Item.Make, searchTerm, options: SearchOptions.Or)
                .Search(a => a.Item.Model, searchTerm, options: SearchOptions.Or)
                .Search(a => a.Item.Color, searchTerm, options: SearchOptions.Or);
        }

        var items = await auctions
            .Skip((auctionSearch.PageNumber - 1) * auctionSearch.PageSize)
            .Take(auctionSearch.PageSize)
            .Select(a => a.Item)
            .ToListAsync(cancellationToken);

        var totalResults = statistics.TotalResults;

        var paginatedResponse = new PaginatedResponse<List<Item>>
        {
            Data = items,
            PageNumber = auctionSearch.PageNumber,
            PageSize = auctionSearch.PageSize,
            TotalCount = totalResults
        };

        return paginatedResponse;
    }
}