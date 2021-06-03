using AutoMapper;
using Pedidos.Domain.Command.Commands.AtualizarPedido;
using Pedidos.Domain.Command.Commands.CriarPedido;
using Pedidos.Domain.Models;

namespace Pedidos.Domain.Command.MapperProfiles
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            CreateMap<CriarPedidoCommand, Pedido>();
            CreateMap<AtualizarPedidoCommand, Pedido>(); 
            CreateMap<Pedido, CriarPedidoCommandResponse>();
            CreateMap<Pedido, AtualizarPedidoCommandResponse>();

        }
    }
}
