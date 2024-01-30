using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Markup;

namespace StackOverflowAnswers.Wpf.Enums
{
    public class EnumViewModel
    {
        public EnumViewModel(Enum value)
        {
            Value = value;
            Description = getDescription(value);
        }

        public Enum Value { get; }
        public string Description { get; }

        private string getDescription(Enum value)
        {
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

    public class EnumBindingSourceExtension : MarkupExtension
    {
        private Type _enumType;
        public Type EnumType
        {
            get => this._enumType;
            set
            {
                if (value == this._enumType) return;

                if (!isEnumType(value)) throw new ArgumentException("Type must be for an Enum.");

                this._enumType = value;
            }
        }

        private bool isEnumType(Type type)
        {
            if (type is null) return false;
            var enumType = Nullable.GetUnderlyingType(type) ?? type;
            return enumType.IsEnum;
        }

        public EnumBindingSourceExtension() { }

        public EnumBindingSourceExtension(Type enumType)
        {
            this.EnumType = enumType;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (this._enumType is null)
                throw new InvalidOperationException("The EnumType must be specified.");

            var actualEnumType = Nullable.GetUnderlyingType(this._enumType) ?? this._enumType;
            var enumValues = Enum.GetValues(actualEnumType)
                .OfType<Enum>()
                .Select(x => new EnumViewModel(x))
                .ToList();

            return enumValues;
        }
    }

    public enum IVAC_VT_SHIFT_SPD
    {
        [Description("16.1299991607666")]
        DATA16,
        [Description("32.130001068115234")]
        DATA32,
    }
}
