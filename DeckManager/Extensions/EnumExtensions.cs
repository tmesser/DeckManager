namespace DeckManager.Extensions
{
    public static class EnumExtensions
    {
        public static string GetStringValue(this System.Enum inputEnum)
        {
            var enumType = inputEnum.GetType();

            var enumField = enumType.GetField(inputEnum.ToString());

            if (enumField == null)
            {
                // this is most likely because the enum uses the FlagAttribute
                return null;
            }

            var enumAttributes = enumField.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];

            if (enumAttributes == null || enumAttributes.Length == 0)
                return null;
            return enumAttributes[0].StringValue;
        }
    }
}
