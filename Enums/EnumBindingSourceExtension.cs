﻿using System;
using System.Windows.Markup;

namespace ThesisLibrary.Enums
{
    //https://www.youtube.com/watch?v=Bp5LFXjwtQ0&t
    public class EnumBindingSourceExtension : MarkupExtension
    {
        public Type EnumType { get; private set; }
        public EnumBindingSourceExtension(Type enumType)
        {
            if (enumType is null || !enumType.IsEnum)
                throw new Exception("EnumType darf nicht null sein und muss vom Typ Enum sein");

            EnumType = enumType;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(EnumType);
        }
    }
}
