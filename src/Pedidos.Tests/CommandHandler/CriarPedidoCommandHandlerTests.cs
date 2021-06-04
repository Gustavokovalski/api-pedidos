using AutoMapper;
using Moq;
using NUnit.Framework;
using Pedidos.Domain.Command.Commands.CriarPedido;
using Pedidos.Domain.Enums;
using Pedidos.Domain.Extensions;
using Pedidos.Domain.Interfaces;
using Pedidos.Domain.Models;
using System.Threading.Tasks;

namespace Pedidos.Tests.CommandHandler
{
    [TestFixture]
    public class CriarPedidoCommandHandlerTests
    {
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IPedidoRepository> _pedidoRepository;

        public CriarPedidoCommandHandlerTests()
        {
            _mapper = new Mock<IMapper>();
            _pedidoRepository = new Mock<IPedidoRepository>();
        }

        [Test]
        public async Task Criar_Pedido_Com_Sucesso()
        {
            //arange
            CriarPedidoCommand command = Faker.CommandHandler.CriarPedidoCommandFaker.CriarPedidoCommand().Generate();
            CriarPedidoCommandHandler handler = new CriarPedidoCommandHandler(_mapper.Object, _pedidoRepository.Object, new CriarPedidoCommandValidator());
           
            //act
            var result = await handler.Handle(command, new System.Threading.CancellationToken());

            //assert
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.ValidationErrors.Count == 0);
            Assert.IsTrue(result.Message.Description.Equals(EnumExtensions.GetEnumDescription(EDefaultResults.Success)));
        }

        [Test]
        public async Task Criar_Pedido_Com_Erro_Validacao()
        {
            //arange
            CriarPedidoCommand command = Faker.CommandHandler.CriarPedidoCommandFaker.CriarPedidoInvalidoCommand().Generate();
            CriarPedidoCommandHandler handler = new CriarPedidoCommandHandler(_mapper.Object, _pedidoRepository.Object, new CriarPedidoCommandValidator());

            //act
            var result = await handler.Handle(command, new System.Threading.CancellationToken());

            //assert
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.ValidationErrors.Count == 1);
            Assert.IsTrue(result.Message.Description.Equals(EnumExtensions.GetEnumDescription(EDefaultResults.ValidationErrors)));
        }

        [Test]
        public async Task Criar_Pedido_Com_Erro_Duplicado()
        {
            //arange
            CriarPedidoCommand command = Faker.CommandHandler.CriarPedidoCommandFaker.CriarPedidoInvalidoDuplicadoCommand().Generate();
            CriarPedidoCommandHandler handler = new CriarPedidoCommandHandler(_mapper.Object, _pedidoRepository.Object, new CriarPedidoCommandValidator());
            _pedidoRepository.Setup(x =>
               x.ObterPorCodigo(command.CodigoPedido))
                   .Returns(Task.FromResult(new Pedido()));

            //act
            var result = await handler.Handle(command, new System.Threading.CancellationToken());

            //assert
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Message.Description.Equals(EnumExtensions.GetEnumDescription(EDefaultResults.Duplicate)));
        }

        [Test]
        public async Task Criar_Pedido_Com_Erro_Itens_Duplicados()
        {
            //arange
            CriarPedidoCommand command = Faker.CommandHandler.CriarPedidoCommandFaker.CriarPedidoInvalidoItensDuplicadosCommand().Generate();
            CriarPedidoCommandHandler handler = new CriarPedidoCommandHandler(_mapper.Object, _pedidoRepository.Object, new CriarPedidoCommandValidator());

            //act
            var result = await handler.Handle(command, new System.Threading.CancellationToken());

            //assert
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Message.Description.Equals(EnumExtensions.GetEnumDescription(EDefaultResults.Duplicateitems)));
        }
    }
}