using AutoMapper;
using PrepaidCard.Core.DTOs;
using PrepaidCard.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Core
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CardEntity, CardDTO>().ReverseMap();
            CreateMap<CustomerEntity, CustomerDTO>().ReverseMap();
            CreateMap<PurchaseEntity, PurchaseDTO>().ReverseMap();
            CreateMap<PurchaseCenterEntity, PurchaseCenterDTO>().ReverseMap();
            CreateMap<StoreEntity, StoreDTO>().ReverseMap();
        }
    }
}
