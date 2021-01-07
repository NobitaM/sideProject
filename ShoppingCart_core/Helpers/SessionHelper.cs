using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart_core.Helpers
{
    public static class SessionHelper
    {
        //object to json
        public static void SetObjectToJson(this ISession session, string key,Object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        //json to object
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            if (value == null)
            {
                return default(T);
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
        }
    }
}
