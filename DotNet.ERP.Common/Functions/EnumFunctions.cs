using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;

namespace DotNet.ERP.Common.Functions
{
  public static class EnumFunctions
    {
        //private static T GetAttribute<T>(this Enum value) where T : Attribute
        //{
        //    if (value == null) return null;
        //    var memberInfo = value.GetType().GetMember(value.ToString());
        //    var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
        //    return (T) attributes[0];
        //}

        private static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            //if (value == null) return null;
            //var memberInfo = value.GetType().GetMember(value.ToString());
            //if (memberInfo == null || memberInfo.Length == 0)
            //    return null;
            //var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            //if (attributes == null || attributes.Length == 0)
            //    return null;
            //return (T)attributes[0];

            if (value == null) return null;
            var memberInfo = value.GetType().GetMember(value.ToString());
            if (memberInfo.Length == 0) return null;
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            if (attributes.Length == 0) return null;
            return (T)attributes[0];
        }

        public static string ToName(this Enum value)
        {
            if (value == null) return null;
            var attribute = value.GetAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }
        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            foreach (var field in type.GetFields())
            {
                if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException($"Tanımsız açıklama: {description}", nameof(description));
        }
        public static ICollection GetEnumDescriptionList<T>()
        {
            return typeof(T).GetMembers()
                .SelectMany(x => x.GetCustomAttributes(typeof(DescriptionAttribute), true)
                    .Cast<DescriptionAttribute>())
                .Select(x => x.Description).ToList();
        }

        public static T GetEnum<T>(this string description)
        {
            if (Enum.IsDefined(typeof(T), description))
                return (T)Enum.Parse(typeof(T), description, true);

            var enumNames = Enum.GetNames(typeof(T));

            foreach (var e in enumNames.Select(x => Enum.Parse(typeof(T), x)).Where(y => description == ToName((Enum) y)))
                return (T)e; 

            return default(T);
        }
    }
}
