using Application.DTO.GraphData;
using Application.Exceptions;
using Application.Interfaces.Services;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Graphs.Queries;

public class GetGraphDataCountOffersOrdersQuery: IRequest<Response<GraphDataDTO>>
{
    public GetGraphDataCountOffersOrdersQuery(int year)
    {
        Year = year;
    }

    public int Year { get; set; }
}

public class GetGraphDataCountOffersOrdersQueryHandler : IRequestHandler<GetGraphDataCountOffersOrdersQuery, Response<GraphDataDTO>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetGraphDataCountOffersOrdersQueryHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<GraphDataDTO>> Handle(GetGraphDataCountOffersOrdersQuery req, CancellationToken cancellationToken)
    {
        ICollection<OfferEntity> offers;
        ICollection<OrderEntity> orders;

        if (DateTime.TryParseExact(req.Year.ToString(), "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateValue))
        {
            var dt = DateTime.SpecifyKind(dateValue, DateTimeKind.Utc);
            offers = await _uow.OfferRepo.FindAllAsync(o => o.Created.Year.Equals(dt.Year));
            orders = await _uow.OrderRepo.FindAllAsync(o => o.Created.Year.Equals(dt.Year));
        } else throw new ApiException("Incorrect year!");

        var dateOffers = _mapper.Map<List<GraphDate>>(offers);
        var dateOrders = _mapper.Map<List<GraphDate>>(orders);
        
        var result = new GraphDataDTO();
        result.Offers = offers.Count > 0 ? this.GetDataCountByMonth(dateOffers) : this.GetEmptyDataCount();
        result.Orders = orders.Count > 0 ? this.GetDataCountByMonth(dateOrders) : this.GetEmptyDataCount();
        return new Response<GraphDataDTO>(result);
    }

    private List<int> GetDataCountByMonth(List<GraphDate> data)
    {
        List<int> result = new List<int>();
        for(int i = 1; i <= 12; i++)
        {
            var count = data.Where(o => o.Date.Month.Equals(i)).Count();
            result.Add(count);
        }
        return result;
    }

    private List<int> GetEmptyDataCount()
    {
        var result = new List<int>();
        for(int i = 1; i <= 12; i++)
        {
            result.Add(0);
        }
        return result;
    }
}

public class GetGraphDataCountOffersOrdersQueryValidator : AbstractValidator<GetGraphDataCountOffersOrdersQuery>
{
    public GetGraphDataCountOffersOrdersQueryValidator()
    {
        RuleFor(p => p.Year)
            .Must(IsCorrect).WithMessage("{PropertyName}: Error! Incorrect year!");
    }

    private bool IsCorrect(int year)
    {
        if(year < 2010) return false;
        return true;
    }
}