using AutoMapper;
using Pedidos.Domain.Command.Commands.ItemPedido;
using Pedidos.Domain.Models;

namespace Pedidos.Domain.Command.MapperProfiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<ItemPedidoCommand, Item>();
        }
    }
}
