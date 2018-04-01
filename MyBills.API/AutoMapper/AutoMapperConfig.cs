using AutoMapper;
using MyBills.API.VIewModels;
using MyBills.Domain.Entities;

namespace MyBills.API.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<BillViewModel, Bill>();
            CreateMap<Bill, BillViewModel>();
        }
    }
}
