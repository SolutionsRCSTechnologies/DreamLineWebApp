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
        private static Cache cache = new Cache();

        private void AddItem(string key, object item)
        {
            lock (new object())
            {
                if (cache[key] != null)
                {
                    cache.Remove(key);
                }
                cache.Insert(key, item, null, DateTime.UtcNow.AddHours(8), Cache.NoSlidingExpiration);
            }
        }

        private object GetItem(string key)
        {
            if (cache[key] == null)
            {
                return null;
            }
            return cache.Get(key);
        }

        public void RefreshCache()
        {
        }
    }
}
