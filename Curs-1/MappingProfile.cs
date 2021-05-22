using System;
using AutoMapper;
using Curs_1.Models;
using Curs_1.ViewModels;
using Curs_1.ViewModels.Orders;

namespace Curs_1
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Comment, CommentViewModel>();
            CreateMap<Product, ProductWithCommentsViewModel>();
            CreateMap<ApplicationUser, ApplicationUserViewModel>().ReverseMap();

            CreateMap<Order, OrdersForUserResponse>().ReverseMap();
        }
    }
}
