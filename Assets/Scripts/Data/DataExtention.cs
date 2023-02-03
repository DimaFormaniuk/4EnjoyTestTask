using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Data
{
    public static class DataExtention
    {
        public static T AsDeserelize<T>(this string json) =>
            JsonUtility.FromJson<T>(json);

        public static string ToJson(this object obj) =>
            JsonUtility.ToJson(obj);

        public static string GetDescription(this Enum GenericEnum)
        {
            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var _Attribs = memberInfo[0]
                    .GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if ((_Attribs != null && _Attribs.Count() > 0))
                {
                    return ((System.ComponentModel.DescriptionAttribute)_Attribs.ElementAt(0)).Description;
                }
            }

            return GenericEnum.ToString();
        }

        public static string ConvertToTime(this long tick)
        {
            return new TimeSpan(tick).ConvertToTime();
        }

        public static string ConvertToTime(this TimeSpan time)
        {
            return time.ToString(@"mm\:ss");
        }

        public static DateTime RoundToDay(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
        }
    }
}