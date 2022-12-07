﻿using AutoMapper;
using CulturaContigo.Api.Mapping;

namespace CulturaContigo.Api.Tests.Mapping;

internal class Mother
{
    public Models.ActivityCreateRequest ModelActivityCreateRequest => new()
    {
        Name = "name",
        Details = "details",
        Capacity = 100,
        Place = "place",
        ImageUrl = "imageurl",
        ScheduledDateTime = DateTime.Now,
        TicketPrice = 10_000m
    };

    public Manager.Activities.Contract.Activity ManagerActivity => new()
    {
        Id = 100,
        Name = "name",
        Details = "details",
        Capacity = 100,
        Place = "place",
        ImageUrl = "imageurl",
        ScheduledDateTime = DateTime.Now,
        TicketPrice = 10_000m
    };

    internal IMapper CreateMapper()
    {
        var configurationExpression = new MapperConfigurationExpression();
        configurationExpression.AddProfile<MappingProfile>();
        var configuration = new MapperConfiguration(configurationExpression);
        configuration.AssertConfigurationIsValid();
        var result = new Mapper(configuration);
        return result;
    }
}