namespace OnlineStore.Web.Areas.Administration.ViewModels.Order
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class DetailsViewModel : IMapFrom<Order>
    {
        public int Id { get; set; }

        public OrderStatus Status { get; set; }

        public IEnumerable<OrderProduct> Products { get; set; }

        public DateTime CreatedOn { get; set; }

        public ApplicationUser User { get; set; }

        public Address Address { get; set; }
    }
}
