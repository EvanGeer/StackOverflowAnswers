using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Markup;

namespace StackOverflowAnswers.Wpf.Enums
{
    public class EnumViewModel
    {
        public EnumViewModel(Enum value, string description)
        {
            Value = value;
            Description = description;
        }

        public Enum Value { get; }
        public string Description { get; }
    }
    public class EnumBindingSourceExtension : MarkupExtension
    {
        private Type _enumType;
        public Type EnumType
        {
            get { return this._enumType; }
            set
            {
                if (value != this._enumType)
                {
                    if (null != value)
                    {
                        Type enumType = Nullable.GetUnderlyingType(value) ?? value;
                        if (!enumType.IsEnum)
                            throw new ArgumentException("Type must be for an Enum.");
                    }

                    this._enumType = value;
                }
            }
        }

        public EnumBindingSourceExtension() { }

        public EnumBindingSourceExtension(Type enumType)
        {
            this.EnumType = enumType;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (null == this._enumType)
                throw new InvalidOperationException("The EnumType must be specified.");

            Type actualEnumType = Nullable.GetUnderlyingType(this._enumType) ?? this._enumType;
            Array enumValues = Enum.GetValues(actualEnumType);

            if (actualEnumType == this._enumType)
                return enumValues;

            Array tempArray = Array.CreateInstance(actualEnumType, enumValues.Length + 1);
            enumValues.CopyTo(tempArray, 1);
            return tempArray;
        }


    }
    public class EnumDescriptionTypeConverter : EnumConverter
    {
        public EnumDescriptionTypeConverter(Type type) : base(type) { }
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType != typeof(string))
                return base.ConvertTo(context, culture, value, destinationType);

            if (!(value?.GetType().GetField(value?.ToString()) is FieldInfo enumField))
                // value is null...
                return string.Empty;

            var descriptionAttribute = enumField.GetCustomAttributes(typeof(DescriptionAttribute), false)
                .OfType<DescriptionAttribute>()
                .FirstOrDefault();

            if (descriptionAttribute is null || string.IsNullOrEmpty(descriptionAttribute.Description)) 
                // description attribute is missing or blank...
                return value.ToString();

            return descriptionAttribute.Description;
        }



    }
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum SampleEnum
    {
        [Description("A nice descrip")]
        Sample1,
        [Description("A nicer description")]
        Sample2,
        [Description("An okay desc.")]
        Sample3,
    }
}
