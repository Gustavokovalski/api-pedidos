using FluentValidation.Results;
using Pedidos.Domain.Enums;
using Pedidos.Domain.Extensions;
using System.Collections.Generic;

namespace Pedidos.Domain.Command.Result
{
    public class ApplicationResult<T>
    {
        public ApplicationResult()
        {
            Data = default;
        }

        public ApplicationResult(bool success, EDefaultResults message)
        {
            Success = success;
            Message = new EnumModel
            {
                Code = message.GetEnumValue(),
                Name = message.GetEnumName(),
                Description = message.GetEnumDescription()
            };
            Data = default;
        }

        public ApplicationResult(bool success, EDefaultResults message, T data) : this(success, message)
        {
            Data = data;
        }

        public ApplicationResult(bool success, EDefaultResults message, List<ValidationFailure> validationErrors) : this(success, message)
        {
            ValidationErrors = validationErrors;
        }

        public T Data { get; set; }
        public EnumModel Message { get; set; }
        public bool Success { get; set; }
        public List<ValidationFailure> ValidationErrors { get; set; } = new List<ValidationFailure>();
    }

    public partial class ApplicationResult : ApplicationResult<dynamic>
    {
        public ApplicationResult() : base()
        {

        }

        public ApplicationResult(bool success, EDefaultResults message) : base(success, message)
        {

        }

        public ApplicationResult(bool success, EDefaultResults message, dynamic data) : base(success, message) => Data = data;
    }
}
