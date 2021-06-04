using AutoMapper;
using Moq;
using NUnit.Framework;
using Pedidos.Domain.Command.Commands.DeletarPedido;
using Pedidos.Domain.Enums;
using Pedidos.Domain.Extensions;
using Pedidos.Domain.Interfaces;
using Pedidos.Domain.Models;
using System.Threading.Tasks;

namespace Pedidos.Tests.CommandHandler
{
    [TestFixture]
    public class DeletarPedidoCommandHandlerTests
    {
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IPedidoRepository> _pedidoRepository;

        public DeletarPedidoCommandHandlerTests()
        {
            _mapper = new Mock<IMapper>();
            _pedidoRepository = new Mock<IPedidoRepository>();
        }

        [Test]
        public async Task Deletar_Pedido_Com_Sucesso()
        {
            //arange
            DeletarPedidoCommand command = new DeletarPedidoCommand("1234");
            DeletarPedidoCommandHandler handler = new DeletarPedidoCommandHandler(_mapper.Object, _pedidoRepository.Object);
            _pedidoRepository.Setup(x =>
               x.ObterPorCodigo(command.Codigo))
                   .Returns(Task.FromResult(new Pedido()));

            //act
            var result = await handler.Handle(command, new System.Threading.CancellationToken());

            //assert
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Message.Description.Equals(EnumExtensions.GetEnumDescription(EDefaultResults.Success)));
        }

        [Test]
        public async Task Deletar_Pedido_Invalido()
        {
            //arange
            DeletarPedidoCommand command = new DeletarPedidoCommand("1234");
            DeletarPedidoCommandHandler handler = new DeletarPedidoCommandHandler(_mapper.Object, _pedidoRepository.Object);
            _pedidoRepository.Setup(x =>
               x.ObterPorCodigo(command.Codigo))
                   .Returns(Task.FromResult((Pedido)null));

            //act
            var result = await handler.Handle(command, new System.Threading.CancellationToken());

            //assert
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Message.Description.Equals(EnumExtensions.GetEnumDescription(EDefaultResults.NotFound)));
        }
    }
}