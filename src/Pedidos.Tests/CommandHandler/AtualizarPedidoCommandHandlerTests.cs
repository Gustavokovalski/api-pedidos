using AutoMapper;
using Moq;
using NUnit.Framework;
using Pedidos.Domain.Command.Commands.AtualizarPedido;
using Pedidos.Domain.Enums;
using Pedidos.Domain.Extensions;
using Pedidos.Domain.Interfaces;
using Pedidos.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedidos.Tests.CommandHandler
{
    [TestFixture]
    public class AtualizarPedidoCommandHandlerTests
    {
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IPedidoRepository> _pedidoRepository;
        private readonly Mock<IPedidoItemRepository> _pedidoItemRepository;

        public AtualizarPedidoCommandHandlerTests()
        {
            _mapper = new Mock<IMapper>();
            _pedidoRepository = new Mock<IPedidoRepository>();
            _pedidoItemRepository = new Mock<IPedidoItemRepository>();
        }

        [Test]
        public async Task Atualizar_Pedido_Com_Sucesso()
        {
            //arange
            AtualizarPedidoCommand command = Faker.CommandHandler.AtualizarPedidoCommandFaker.AtualizarPedidoSucessoCommand().Generate();
            AtualizarPedidoCommandHandler handler = new AtualizarPedidoCommandHandler(_mapper.Object, _pedidoRepository.Object, _pedidoItemRepository.Object, new AtualizarPedidoCommandValidator());

            var sample = new List<Item>()
                   {
                       new Item()
                       {
                           Id = 1,
                           PedidoId = 1,
                           Descricao = "Item 1",
                           PrecoUnitario = 100,
                           Quantidade = 1
                       }
                   };

            _pedidoRepository.Setup(x =>
                      x.ObterPorCodigo(command.CodigoPedido))
                          .Returns(Task.FromResult(new Pedido() { CodigoPedido = command.CodigoPedido, Itens = sample, Id = 1 }));

            //act
            var result = await handler.Handle(command, new System.Threading.CancellationToken());

            //assert
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.ValidationErrors.Count == 0);
            Assert.IsTrue(result.Message.Description.Equals(EnumExtensions.GetEnumDescription(EDefaultResults.SuccessEdit)));
        }

        [Test]
        public async Task Atualizar_Pedido_Inexistente()
        {
            //arange
            AtualizarPedidoCommand command = Faker.CommandHandler.AtualizarPedidoCommandFaker.AtualizarPedidoInvalidoCommand().Generate();
            AtualizarPedidoCommandHandler handler = new AtualizarPedidoCommandHandler(_mapper.Object, _pedidoRepository.Object, _pedidoItemRepository.Object, new AtualizarPedidoCommandValidator());
            _pedidoRepository.Setup(x =>
                  x.ObterPorCodigo(command.CodigoPedido))
                      .Returns(Task.FromResult((Pedido)null));

            //act
            var result = await handler.Handle(command, new System.Threading.CancellationToken());

            //assert
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Message.Description.Equals(EnumExtensions.GetEnumDescription(EDefaultResults.NotFound)));
        }

        [Test]
        public async Task Atualizar_Pedido_Invalido_Erro_Validacao()
        {
            //arange
            AtualizarPedidoCommand command = Faker.CommandHandler.AtualizarPedidoCommandFaker.AtualizarPedidoInvalidoCommand().Generate();
            AtualizarPedidoCommandHandler handler = new AtualizarPedidoCommandHandler(_mapper.Object, _pedidoRepository.Object, _pedidoItemRepository.Object, new AtualizarPedidoCommandValidator());
            _pedidoRepository.Setup(x =>
                  x.ObterPorCodigo(command.CodigoPedido))
                      .Returns(Task.FromResult(new Pedido()));

            //act
            var result = await handler.Handle(command, new System.Threading.CancellationToken());

            //assert
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.ValidationErrors.Count == 2);
            Assert.IsTrue(result.Message.Description.Equals(EnumExtensions.GetEnumDescription(EDefaultResults.ValidationErrors)));
        }

        [Test]
        public async Task Atualizar_Pedido_Invalido_Itens_Duplicados()
        {
            //arange
            AtualizarPedidoCommand command = Faker.CommandHandler.AtualizarPedidoCommandFaker.AtualizarPedidoInvalidoItensDuplicadosCommand().Generate();
            AtualizarPedidoCommandHandler handler = new AtualizarPedidoCommandHandler(_mapper.Object, _pedidoRepository.Object, _pedidoItemRepository.Object, new AtualizarPedidoCommandValidator());
            _pedidoRepository.Setup(x =>
                  x.ObterPorCodigo(command.CodigoPedido))
                      .Returns(Task.FromResult(new Pedido()));

            //act
            var result = await handler.Handle(command, new System.Threading.CancellationToken());

            //assert
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Message.Description.Equals(EnumExtensions.GetEnumDescription(EDefaultResults.Duplicateitems)));
        }
    }
}
