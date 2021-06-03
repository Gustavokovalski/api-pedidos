using AutoMapper;
using Pedidos.Domain.Models;
using Pedidos.Domain.Query.Queries.ObterPedidoPorCodigo;
using Pedidos.Domain.Query.Queries.ObterPedidos;

namespace Pedidos.Domain.Query.MapperQueryProfiles
{
    public class PedidoQueryProfile : Profile   
    {
        public PedidoQueryProfile()
        {
            CreateMap<Pedido, ObterPedidosQueryResponse>();
            CreateMap<Pedido, ObterPedidoPorCodigoQueryResponse>();
        }
    }
    
}
