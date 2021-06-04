using AutoMapper;
using Moq;
using NUnit.Framework;
using Pedidos.Domain.Enums;
using Pedidos.Domain.Extensions;
using Pedidos.Domain.Interfaces;
using Pedidos.Domain.Query.Queries.ObterPedidos;
using System.Threading.Tasks;

namespace Pedidos.Tests.QueryHandler
{

    [TestFixture]
    public class ObterPedidosQueryHandlerTests
    {
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IPedidoRepository> _pedidoRepository;

        public ObterPedidosQueryHandlerTests()
        {
            _mapper = new Mock<IMapper>();
            _pedidoRepository = new Mock<IPedidoRepository>();
        }

        [Test]
        public async Task Obter_Todos()
        {
            //arange
            ObterPedidosQuery query = new ObterPedidosQuery();
            ObterPedidosQueryHandler handler = new ObterPedidosQueryHandler(_mapper.Object, _pedidoRepository.Object);
           
            //act
            var result = await handler.Handle(query, new System.Threading.CancellationToken());

            //assert
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Message.Description.Equals(EnumExtensions.GetEnumDescription(EDefaultResults.Success)));
        }
    }
}
