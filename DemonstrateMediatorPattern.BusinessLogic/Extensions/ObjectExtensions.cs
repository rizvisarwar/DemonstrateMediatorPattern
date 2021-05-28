using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemonstrateMediatorPattern.BusinessLogic.Extensions
{
    public static class ObjectExtensions
    {
        public static JArray ToJArray<T>(this IEnumerable<T> model)
        {
            var serializer = new JsonSerializer
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };

            return JArray.FromObject(model, serializer);
        }

        /// <summary>
        /// Serialize Object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string SerializeObject<T>(this T model)
        {
            var serializer = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };

            return JsonConvert.SerializeObject(model, serializer);
        }

        public static IEnumerable<TFirst> MapList<TFirst, TSecond, TKey>
              (
              this IEnumerable<TFirst> first,
              IEnumerable<TSecond> second,
              Func<TFirst, TKey> firstKey,
              Func<TSecond, TKey> secondKey,
              Action<TFirst, IEnumerable<TSecond>> addChildren
              )
        {
            var childMap = second
                .GroupBy(s => secondKey(s))
                .ToDictionary(g => g.Key, g => g.AsEnumerable());

            foreach (var item in first)
            {
                childMap.TryGetValue(firstKey(item), out IEnumerable<TSecond> children);
                addChildren(item, children ?? Enumerable.Empty<TSecond>());
            }

            return first;
        }
    }
}
