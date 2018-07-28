using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;

namespace Common
{
    public class ApplicationCache
    {
        private static Cache cache = null;
        public ApplicationCache()
        {
            if (cache == null)
            {
                cache = new Cache();
            }
        }
        private string cache_key = "DREAMLINE_CACHE";
        //private void AddItem(string key, object item)
        //{
        //    lock (new object())
        //    {
        //        if (cache[key] != null)
        //        {
        //            cache.Remove(key);
        //        }
        //        cache.Insert(key, item, null, DateTime.UtcNow.AddHours(8), Cache.NoSlidingExpiration);
        //    }
        //}

        public object GetItem(string key)
        {
            object retObj = null;
            Dictionary<string, object> obj = null;
            if (cache[cache_key] == null)
            {
                RefreshCache();
            }
            obj = cache[cache_key] != null ? (Dictionary<string, object>)cache.Get(cache_key) : null;
            if (obj != null && obj.ContainsKey(key))
            {
                obj.TryGetValue(key, out retObj);
            }
            return retObj;
        }

        private void RefreshCache()
        {
            DBHelper helper = new DBHelper();
            Dictionary<string, object> obj = helper.GetCacheItems();
            lock (new object())
            {
                if (cache[cache_key] != null)
                {
                    cache.Remove(cache_key);
                }
                cache.Insert(cache_key, obj, null, DateTime.UtcNow.AddHours(8), Cache.NoSlidingExpiration);
            }
        }
    }
}
