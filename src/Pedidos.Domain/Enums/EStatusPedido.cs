using System.ComponentModel;

namespace Pedidos.Domain.Enums
{
    public enum EStatusPedido
    {
        [Description("APROVADO")]
        Aprovado = 1,

        [Description("REPROVADO")]
        Reprovado = 2,

        [Description("APROVADO_VALOR_A_MENOR")]
        AprovadoValorMenor = 3,

        [Description("APROVADO_VALOR_A_MAIOR")]
        AprovadoValorMaior = 4,

        [Description("APROVADO_QTD_A_MENOR")]
        AprovadoQuantidadeMenor = 5,

        [Description("APROVADO_QTD_A_MAIOR")]
        AprovadoQuantidadeMaior = 6,

        [Description("CODIGO_PEDIDO_INVALIDO")]
        CodigoPedidoInvalido = 7
    }
}
