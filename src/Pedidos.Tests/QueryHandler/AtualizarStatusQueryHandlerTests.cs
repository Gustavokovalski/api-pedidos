using Moq;
using NUnit.Framework;
using Pedidos.Domain.Enums;
using Pedidos.Domain.Extensions;
using Pedidos.Domain.Interfaces;
using Pedidos.Domain.Models;
using Pedidos.Domain.Query.Queries.AtualizarStatus;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedidos.Tests.QueryHandler
{

    [TestFixture]
    public class AtualizarStatusQueryHandlerTests
    {
        private readonly Mock<IPedidoRepository> _pedidoRepository;

        public AtualizarStatusQueryHandlerTests()
        {
            _pedidoRepository = new Mock<IPedidoRepository>();
        }

        [Test]
        public async Task Atualizar_Status_Invalido()
        {
            //arange
            AtualizarStatusQuery query = Faker.QueryHandler.AtualizarStatusQueryFaker.AtualizarStatusInvalido().Generate();
            AtualizarStatusQueryHandler handler = new AtualizarStatusQueryHandler(_pedidoRepository.Object, new AtualizarStatusQueryValidator());

            //act
            var result = await handler.Handle(query, new System.Threading.CancellationToken());

            //assert
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.ValidationErrors.Count == 1);
            Assert.IsTrue(result.Message.Description.Equals(EnumExtensions.GetEnumDescription(EDefaultResults.ValidationErrors)));
        }

        [Test]
        public async Task Atualizar_Status_Aprovado()
        {
            //arange
            AtualizarStatusQuery query = Faker.QueryHandler.AtualizarStatusQueryFaker.AtualizarStatusAprovado().Generate();
            AtualizarStatusQueryHandler handler = new AtualizarStatusQueryHandler(_pedidoRepository.Object, new AtualizarStatusQueryValidator());

            var sample = new List<Item>()
                   {
                       new Item()
                       {
                           Id = 1,
                           PedidoId = 1,
                           Descricao = "Item 1",
                           PrecoUnitario = 2,
                           Quantidade = 5
                       }
                   };

            _pedidoRepository.Setup(x =>
                   x.ObterPorCodigo(query.Pedido))
                       .Returns(Task.FromResult(new Pedido() { Id = 1, CodigoPedido = "1", Itens = sample}));

            //act
            var result = await handler.Handle(query, new System.Threading.CancellationToken());

            //assert
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Data.Status.Contains(EnumExtensions.GetEnumDescription(EStatusPedido.Aprovado)));
        }

        [Test]
        public async Task Atualizar_Status_Reprovado()
        {
            //arange
            AtualizarStatusQuery query = Faker.QueryHandler.AtualizarStatusQueryFaker.AtualizarStatusReprovado().Generate();
            AtualizarStatusQueryHandler handler = new AtualizarStatusQueryHandler(_pedidoRepository.Object, new AtualizarStatusQueryValidator());

            var sample = new List<Item>()
                   {
                       new Item()
                       {
                           Id = 1,
                           PedidoId = 1,
                           Descricao = "Item 1",
                           PrecoUnitario = 10,
                           Quantidade = 5
                       }
                   };

            _pedidoRepository.Setup(x =>
                   x.ObterPorCodigo(query.Pedido))
                       .Returns(Task.FromResult(new Pedido() { Id = 1, CodigoPedido = "1", Itens = sample }));

            //act
            var result = await handler.Handle(query, new System.Threading.CancellationToken());

            //assert
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Data.Status.Contains(EnumExtensions.GetEnumDescription(EStatusPedido.Reprovado)));
        }

        [Test]
        public async Task Atualizar_Status_Aprovado_Valor_Menor()
        {
            //arange
            AtualizarStatusQuery query = Faker.QueryHandler.AtualizarStatusQueryFaker.AtualizarStatusAprovado().Generate();
            AtualizarStatusQueryHandler handler = new AtualizarStatusQueryHandler(_pedidoRepository.Object, new AtualizarStatusQueryValidator());

            var sample = new List<Item>()
                   {
                       new Item()
                       {
                           Id = 1,
                           PedidoId = 1,
                           Descricao = "Item 1",
                           PrecoUnitario = 20,
                           Quantidade = 5
                       }
                   };

            _pedidoRepository.Setup(x =>
                   x.ObterPorCodigo(query.Pedido))
                       .Returns(Task.FromResult(new Pedido() { Id = 1, CodigoPedido = "1", Itens = sample }));

            //act
            var result = await handler.Handle(query, new System.Threading.CancellationToken());

            //assert
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Data.Status.Contains(EnumExtensions.GetEnumDescription(EStatusPedido.AprovadoValorMenor)));
        }

        [Test]
        public async Task Atualizar_Status_Aprovado_Valor_Maior()
        {
            //arange
            AtualizarStatusQuery query = Faker.QueryHandler.AtualizarStatusQueryFaker.AtualizarStatusAprovado().Generate();
            AtualizarStatusQueryHandler handler = new AtualizarStatusQueryHandler(_pedidoRepository.Object, new AtualizarStatusQueryValidator());

            var sample = new List<Item>()
                   {
                       new Item()
                       {
                           Id = 1,
                           PedidoId = 1,
                           Descricao = "Item 1",
                           PrecoUnitario = 1,
                           Quantidade = 5
                       }
                   };

            _pedidoRepository.Setup(x =>
                   x.ObterPorCodigo(query.Pedido))
                       .Returns(Task.FromResult(new Pedido() { Id = 1, CodigoPedido = "1", Itens = sample }));

            //act
            var result = await handler.Handle(query, new System.Threading.CancellationToken());

            //assert
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Data.Status.Contains(EnumExtensions.GetEnumDescription(EStatusPedido.AprovadoValorMaior)));
        }

        [Test]
        public async Task Atualizar_Status_Aprovado_Qtd_Menor()
        {
            //arange
            AtualizarStatusQuery query = Faker.QueryHandler.AtualizarStatusQueryFaker.AtualizarStatusAprovado().Generate();
            AtualizarStatusQueryHandler handler = new AtualizarStatusQueryHandler(_pedidoRepository.Object, new AtualizarStatusQueryValidator());

            var sample = new List<Item>()
                   {
                       new Item()
                       {
                           Id = 1,
                           PedidoId = 1,
                           Descricao = "Item 1",
                           PrecoUnitario = 10,
                           Quantidade = 20
                       }
                   };

            _pedidoRepository.Setup(x =>
                   x.ObterPorCodigo(query.Pedido))
                       .Returns(Task.FromResult(new Pedido() { Id = 1, CodigoPedido = "1", Itens = sample }));

            //act
            var result = await handler.Handle(query, new System.Threading.CancellationToken());

            //assert
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Data.Status.Contains(EnumExtensions.GetEnumDescription(EStatusPedido.AprovadoQuantidadeMenor)));
        }

        [Test]
        public async Task Atualizar_Status_Aprovado_Qtd_Maior()
        {
            //arange
            AtualizarStatusQuery query = Faker.QueryHandler.AtualizarStatusQueryFaker.AtualizarStatusAprovado().Generate();
            AtualizarStatusQueryHandler handler = new AtualizarStatusQueryHandler(_pedidoRepository.Object, new AtualizarStatusQueryValidator());

            var sample = new List<Item>()
                   {
                       new Item()
                       {
                           Id = 1,
                           PedidoId = 1,
                           Descricao = "Item 1",
                           PrecoUnitario = 10,
                           Quantidade = 2
                       }
                   };

            _pedidoRepository.Setup(x =>
                   x.ObterPorCodigo(query.Pedido))
                       .Returns(Task.FromResult(new Pedido() { Id = 1, CodigoPedido = "1", Itens = sample }));

            //act
            var result = await handler.Handle(query, new System.Threading.CancellationToken());

            //assert
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Data.Status.Contains(EnumExtensions.GetEnumDescription(EStatusPedido.AprovadoQuantidadeMaior)));
        }

        [Test]
        public async Task Atualizar_Status_Aprovado_Codigo_Invalido()
        {
            //arange
            AtualizarStatusQuery query = Faker.QueryHandler.AtualizarStatusQueryFaker.AtualizarStatusAprovado().Generate();
            AtualizarStatusQueryHandler handler = new AtualizarStatusQueryHandler(_pedidoRepository.Object, new AtualizarStatusQueryValidator());
           
            _pedidoRepository.Setup(x =>
                   x.ObterPorCodigo(query.Pedido))
                       .Returns(Task.FromResult((Pedido)null));

            //act
            var result = await handler.Handle(query, new System.Threading.CancellationToken());

            //assert
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Data.Status.Contains(EnumExtensions.GetEnumDescription(EStatusPedido.CodigoPedidoInvalido)));
        }
    }
}
