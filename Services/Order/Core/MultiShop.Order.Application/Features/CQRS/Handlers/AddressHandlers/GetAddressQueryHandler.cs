﻿using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var result = await _repository.GetAllAsync();
            return result.Select(x => new GetAddressQueryResult
            {
                AddressId = x.AddressId,
                UserId = x.UserId,
                City = x.City,
                District = x.District,
                Detail = x.Detail
            }).ToList();
        }
    }
}