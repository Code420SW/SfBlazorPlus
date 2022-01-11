using Code420.SfBlazorPlus.Code.Enums;
using System.ComponentModel;

namespace Code420.SfBlazorPlus.Code.Extensions
{
    public static class EnumExtensions
    {
        public static string ToCssString(this ButtonStyle val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[]) val
               .GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : String.Empty;
        }

        public static string ToCssString(this SpinnerType val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[]) val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : String.Empty;
        }

        public static string ToCssString(this DialogBoxPositionPreset val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[]) val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : String.Empty;
        }

        public static string ToCssString(this IconButtonStyle val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[]) val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : String.Empty;
        }
    }
}
