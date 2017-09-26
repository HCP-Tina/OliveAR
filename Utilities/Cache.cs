using System;
using System.Collections;
using System.Web.Hosting;

namespace OliveAR.Utilities
{
    public interface ICache : IEnumerable
    {
        object Get(string key);
        T Get<T>(string key) where T : class;
        void Insert(string key, object value);
        void Insert<T>(string key, T value) where T : class;
        object Remove(string key);
        T Remove<T>(string key) where T : class;
    }

    public interface IWebCache : ICache { }

    public class WebCache : IWebCache
    {
        private readonly System.Web.Caching.Cache _webCache;
        private readonly TimeSpan _slidingExpiration;
        private const int ExpirationMinutes = 60;

        public WebCache()
        {
            _webCache = HostingEnvironment.Cache;
            _slidingExpiration = TimeSpan.FromMinutes(ExpirationMinutes);
        }

        public IEnumerator GetEnumerator()
        {
            return _webCache.GetEnumerator();
        }

        public object Get(string key)
        {
            return _webCache.Get(key);
        }

        public T Get<T>(string key) where T : class
        {
            return _webCache.Get(key) as T;
        }

        public void Insert(string key, object value)
        {
            _webCache.Insert(key, value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, _slidingExpiration);
        }

        public void Insert<T>(string key, T value) where T : class
        {
            _webCache.Insert(key, value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, _slidingExpiration);
        }

        public object Remove(string key)
        {
            return _webCache.Remove(key);
        }

        public T Remove<T>(string key) where T : class
        {
            return _webCache.Remove(key) as T;
        }
    }
}

