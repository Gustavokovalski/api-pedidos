﻿using Pedidos.Domain.Extensions;
using System;

namespace Pedidos.Domain.Command.Result
{
    public class EnumModel
    {
        public EnumModel()
        {

        }

        public EnumModel(Enum enumItem)
        {
            Code = enumItem.GetEnumValue();
            Name = enumItem.GetEnumName();
            Description = enumItem.GetEnumDescription();
        }

        public int Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
