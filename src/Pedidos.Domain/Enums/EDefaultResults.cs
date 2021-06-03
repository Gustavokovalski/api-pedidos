using System.ComponentModel;

namespace Pedidos.Domain.Enums
{
    public enum EDefaultResults
    {
        [Description("Ocorreu um erro desconhecido. Tente novamente mais tarde.")]
        InternalError = 99,

        [Description("Operação ocorreu com sucesso.")]
        Success = 1,

        [Description("Um ou mais erros de validação ocorreram.")]
        ValidationErrors = 2,
        
        [Description("Código de pedido informado já existe.")]
        Duplicate = 3,

        [Description("O pedido não pode conter itens duplicados, a descrição deve ser diferente.")]
        Duplicateitems = 4,

        [Description("Pedido não encontrado.")]
        NotFound = 5,

        [Description("Atualização realizada com sucesso.")]
        SuccessEdit = 6,
    }
}
