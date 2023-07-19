using AutoMapper;
using MarketManager.Application.UseCases.Carts.Commands.CreateCart;
using MarketManager.Application.UseCases.Carts.Commands.DeleteCart;
using MarketManager.Application.UseCases.Carts.Commands.UpdateCart;
using MarketManager.Domain.Entities;

namespace MarketManager.Application.Common.Mappings
{
    public class CartMapping : Profile
    {
        public CartMapping()
        {
            CartMappings();
            CartWithCart();
        }

        private void CartWithCart()
        {
            CreateMap<CreateCartCommand, Cart>();
            CreateMap<UpdateCartCommand, Cart>();
            CreateMap<DeleteCartCommand, Cart>();
        }

        private void CartMappings()
        {
            CreateMap<Cart, GetCartByIdResponse>();
            CreateMap<Cart, GetAllCartQueryResponse>();
        }
    }
}
