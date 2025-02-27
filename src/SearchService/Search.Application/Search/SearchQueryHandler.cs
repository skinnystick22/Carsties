﻿using Carsties.Core;
using ErrorOr;
using MediatR;
using Search.Application.Interfaces;
using Search.Domain.Auctions;
using Search.Domain.Items;

namespace Search.Application.Search;

public sealed class SearchQueryHandler : IRequestHandler<SearchQuery, ErrorOr<PaginatedResponse<List<Auction>>>>
{
    private readonly ISearchRepository _searchRepository;

    public SearchQueryHandler(ISearchRepository searchRepository)
    {
        _searchRepository = searchRepository;
    }

    public async Task<ErrorOr<PaginatedResponse<List<Auction>>>> Handle(SearchQuery request,
        CancellationToken cancellationToken)
    {
        var paginatedItems = await _searchRepository.SearchItemsAsync(request.AuctionSearch, cancellationToken);

        return paginatedItems;
    }
}