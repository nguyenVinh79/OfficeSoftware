using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OfficeSoftware.Model
{
    public enum DayDetail
    {
        [Description("CN")]
        Sunday = 0,
        [Description("Thứ 2")]
        Monday = 1,
        [Description("Thứ 3")]
        Tuesday = 2,
        [Description("Thứ 4")]
        Wednesday = 3,
        [Description("Thứ 5")]
        Thursday = 4,
        [Description("Thứ 6")]
        Friday = 5,
        [Description("Thứ 7")]
        Saturday = 6
    }


    public static class EnumExtensionMethods
    {
        public static string GetEnumDescription(this Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : enumValue.ToString();
        }

    }
}

