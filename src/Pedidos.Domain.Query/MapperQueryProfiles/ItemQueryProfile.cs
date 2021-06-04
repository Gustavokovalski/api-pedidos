using AutoMapper;
using Pedidos.Domain.Models;
using Pedidos.Domain.Query.Queries.ItemPedido;

namespace Pedidos.Domain.Query.MapperQueryProfiles
{
    public class ItemQueryProfile : Profile
    {
        public ItemQueryProfile()
        {
            CreateMap<Item, ItemPedidoQuery>();
        }
    }
}
