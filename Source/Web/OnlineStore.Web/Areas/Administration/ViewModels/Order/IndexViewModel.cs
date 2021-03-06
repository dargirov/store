﻿namespace OnlineStore.Web.Areas.Administration.ViewModels.Order
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class IndexViewModel : IMapFrom<Order>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public OrderStatus Status { get; set; }

        public IEnumerable<OrderProduct> Products { get; set; }

        public DateTime CreatedOn { get; set; }

        public string FullName { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Order, IndexViewModel>()
                .ForMember(x => x.FullName, opt => opt.MapFrom(x => x.User.FirstName + " " + x.User.LastName + " (" + x.User.Email + ")"));
        }
    }
}
