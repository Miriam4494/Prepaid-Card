using AutoMapper;
using PrepaidCard.API.PostModels;
using PrepaidCard.Core.DTOs;
using PrepaidCard.Core.Entities;

namespace PrepaidCard.API
{
    public class MappingPostProfile:Profile
    {

        public MappingPostProfile()
        {
            CreateMap<CardPostModel, CardDTO>();
            CreateMap<CustomerPostModel, CustomerDTO>();
            CreateMap<PurchasePostModel, PurchaseDTO>();
            CreateMap<PurchaseCenterPostModel, PurchaseCenterDTO>();
            CreateMap<StorePostModel, StoreDTO>();

        }
    }
}
