using AutoMapper;
using Moq;
using NUnit.Framework;
using Pedidos.Domain.Enums;
using Pedidos.Domain.Extensions;
using Pedidos.Domain.Interfaces;
using Pedidos.Domain.Query.Queries.ObterPedidoPorCodigo;
using System.Threading.Tasks;

namespace Pedidos.Tests.QueryHandler
{

    [TestFixture]
    public class ObterPedidoPorCodigoQueryHandlerTests
    {
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IPedidoRepository> _pedidoRepository;

        public ObterPedidoPorCodigoQueryHandlerTests()
        {
            _mapper = new Mock<IMapper>();
            _pedidoRepository = new Mock<IPedidoRepository>();
        }

        [Test]
        public async Task Obter_Por_Codigo()
        {
            //arange
            ObterPedidoPorCodigoQuery query = new ObterPedidoPorCodigoQuery("1234");
            ObterPedidoPorCodigoQueryHandler handler = new ObterPedidoPorCodigoQueryHandler(_mapper.Object, _pedidoRepository.Object);
           
            //act
            var result = await handler.Handle(query, new System.Threading.CancellationToken());

            //assert
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Message.Description.Equals(EnumExtensions.GetEnumDescription(EDefaultResults.Success)));
        }
    }
}
