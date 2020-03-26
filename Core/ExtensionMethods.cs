using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Core
{
    public static class ExtensionMethods
    {
        #region Fields

        private static readonly Random Rnd = new Random();

        #endregion

        #region Methods

        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
                action(item);
        }

        public static T GetAttribute<T>(this Type type, bool inherited = false)
            where T : Attribute
        {
            return type?
                .GetCustomAttributes(typeof(T), inherited)?
                .SingleOrDefault()
                as T;
        }

        public static T GetAttribute<T>(this MemberInfo memberInfo, bool inherited = false)
            where T : Attribute
        {
            return memberInfo?
                .GetCustomAttributes(typeof(T), inherited)?
                .SingleOrDefault()
                as T;
        }

        public static TKey RandomKey<TKey, TValue>(this IDictionary<TKey, TValue> map)
        {
            var index = Rnd.Next(map.Keys.Count);
            return map.Keys.ToArray()[index];
        }

        public static TValue RandomValue<TKey, TValue>(this IDictionary<TKey, TValue> map)
        {
            return map[map.RandomKey()];
        }

        public static T RandomElement<T>(this IList<T> list)
        {
            var index = Rnd.Next(list.Count);
            return list[index];
        }

        public static bool IsBetween<T>(this T value, T start, T end)
            where T : IComparable<T>
        {
            return value.CompareTo(start) >= 0
                && value.CompareTo(end) <= 0;
        }

        #endregion
    }
}