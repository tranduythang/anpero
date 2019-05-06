using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace Utilities.Caching
{
    /// <summary>
    /// A cached collection of key value pairs. This can be used to cache objects internally on the server.
    /// </summary>
    public sealed class CacheService : ICacheService
    {
        private readonly MemoryCache memoryCache;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheService"/> class using the default <see cref="MemoryCache"/>.
        /// </summary>
        public CacheService()
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60.0);

            this.memoryCache = MemoryCache.Default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheService"/> class.
        /// </summary>
        /// <param name="memoryCache">The memory cache.</param>
        public CacheService(MemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }


        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the total number of cache entries in the cache.
        /// </summary>
        public long Count
        {
            get { return this.memoryCache.GetCount(); }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Inserts a cache entry into the cache by using a key, a value and no expiration.
        /// </summary>
        /// <typeparam name="T">The type of the cache entry value.</typeparam>
        /// <param name="key">A unique identifier for the cache entry to insert.</param>
        /// <param name="value">The data for the cache entry.</param>
        /// <param name="afterItemRemoved">The action to perform after the cache entry has been removed.</param>
        /// <param name="beforeItemRemoved">The action to perform before the cache entry has been removed.</param>
        public void AddOrUpdate<T>(
            string key,
            T value,
            Action<string, T> afterItemRemoved = null,
            Action<string, T> beforeItemRemoved = null) where T : class
        {
            this.AddOrUpdate(key, value, null, null, afterItemRemoved, beforeItemRemoved);
        }

        /// <summary>
        /// Inserts a cache entry into the cache by using a key, a value and absolute expiration.
        /// </summary>
        /// <typeparam name="T">The type of the cache entry value.</typeparam>
        /// <param name="key">A unique identifier for the cache entry to insert.</param>
        /// <param name="value">The data for the cache entry.</param>
        /// <param name="absoluteExpiration">The absolute expiration time, after which the cache entry will expire.</param>
        /// <param name="afterItemRemoved">The action to perform after the cache entry has been removed.</param>
        /// <param name="beforeItemRemoved">The action to perform before the cache entry has been removed.</param>
        public void AddOrUpdate<T>(
            string key,
            T value,
            DateTimeOffset absoluteExpiration,
            Action<string, T> afterItemRemoved = null,
            Action<string, T> beforeItemRemoved = null) where T : class
        {
            this.AddOrUpdate(key, value, absoluteExpiration, null, afterItemRemoved, beforeItemRemoved);
        }

        /// <summary>
        /// Inserts a cache entry into the cache by using a key, a value and sliding expiration.
        /// </summary>
        /// <typeparam name="T">The type of the cache entry value.</typeparam>
        /// <param name="key">A unique identifier for the cache entry to insert.</param>
        /// <param name="value">The data for the cache entry.</param>
        /// <param name="slidingExpiration">The sliding expiration time, after which the cache entry will expire.</param>
        /// <param name="afterItemRemoved">The action to perform after the cache entry has been removed.</param>
        /// <param name="beforeItemRemoved">The action to perform before the cache entry has been removed.</param>
        public void AddOrUpdate<T>(
            string key,
            T value,
            TimeSpan slidingExpiration,
            Action<string, T> afterItemRemoved = null,
            Action<string, T> beforeItemRemoved = null) where T : class
        {
            this.AddOrUpdate(key, value, null, slidingExpiration, afterItemRemoved, beforeItemRemoved);
        }

        /// <summary>
        /// Clears all cache entry items from the cache.
        /// </summary>
        public void Clear()
        {
            foreach (KeyValuePair<string, object> item in this.memoryCache.ToArray())
            {
                this.memoryCache.Remove(item.Key);
            }
        }

        /// <summary>
        /// Determines whether a cache entry exists in the cache with the specified key.
        /// </summary>
        /// <param name="key">A unique identifier for the cache entry.</param>
        /// <returns><c>true</c> if a cache entry exists, otherwise <c>false</c>.</returns>
        /// <exception cref="System.ArgumentNullException">key is null.</exception>
        public bool Contains(string key)
        {
            return this.memoryCache.Contains(key);
        }

        /// <summary>
        /// Query cache as IEnumerable from cache key satify predicate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="predecate"></param>
        /// <returns></returns>
        public IEnumerable<T> Query<T>(string key, Func<T, bool> predecate)
        {
            try
            {
                var query = this.memoryCache.Get(key) as IEnumerable<T>;

                var result = query.Where(predecate);

                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets an entry from the cache with the specified key.
        /// </summary>
        /// <typeparam name="T">The type of the cache entry to get.</typeparam>
        /// <param name="key">A unique identifier for the cache entry to get.</param>
        /// <returns>A reference to the cache entry that is identified by key, if the entry exists; otherwise, <c>null</c>.</returns>
        /// <exception cref="System.ArgumentNullException">key is null.</exception>
        public T Get<T>(string key) where T : class
        {
            return (T)this.memoryCache.Get(key);
        }

        /// <summary>
        /// Try gets an entry from the cache with the specified key.
        /// </summary>
        /// <typeparam name="T">The type of the cache entry to get.</typeparam>
        /// <param name="key">A unique identifier for the cache entry to get.</param>
        /// <output>A reference to the cache entry that is identified by key, if the entry exists; otherwise, <c>null</c>.</output>
        /// <returns>A bool variable determine whether get successfully or not</returns>
        /// <exception cref="System.ArgumentNullException">key is null.</exception>
        public bool TryGet<T>(string key, out T output) where T : class
        {
            output = null;

            try
            {
                output = (T)this.memoryCache.Get(key);

                if (output == null)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets an entry from the cache with the specified key, or if the entry does not exist, inserts a
        /// cache entry into the cache by using a key, a value and no expiration and returns it.
        /// </summary>
        /// <typeparam name="T">The type of the cache entry value.</typeparam>
        /// <param name="key">A unique identifier for the cache entry to insert.</param>
        /// <param name="value">The data for the cache entry.</param>
        /// <param name="afterItemRemoved">The action to perform after the cache entry has been removed.</param>
        /// <param name="beforeItemRemoved">The action to perform before the cache entry has been removed.</param>
        /// <returns>A reference to the cache entry that is identified by key.</returns>
        public T GetOrAdd<T>(
            string key,
            Func<T> value,
            Action<string, T> afterItemRemoved = null,
            Action<string, T> beforeItemRemoved = null) where T : class
        {
            return this.GetOrAdd(key, value, null, null, afterItemRemoved, beforeItemRemoved);
        }

        /// <summary>
        /// Gets an entry from the cache with the specified key, or if the entry does not exist, inserts a
        /// cache entry into the cache by using a key, a value and absolute expiration and returns it.
        /// </summary>
        /// <typeparam name="T">The type of the cache entry value.</typeparam>
        /// <param name="key">A unique identifier for the cache entry to insert.</param>
        /// <param name="value">The data for the cache entry.</param>
        /// <param name="absoluteExpiration">The absolute expiration time, after which the cache entry will expire.</param>
        /// <param name="afterItemRemoved">The action to perform after the cache entry has been removed.</param>
        /// <param name="beforeItemRemoved">The action to perform before the cache entry has been removed.</param>
        /// <returns>A reference to the cache entry that is identified by key.</returns>
        public T GetOrAdd<T>(
            string key,
            Func<T> value,
            DateTimeOffset absoluteExpiration,
            Action<string, T> afterItemRemoved = null,
            Action<string, T> beforeItemRemoved = null) where T : class
        {
            return this.GetOrAdd(key, value, absoluteExpiration, null, afterItemRemoved, beforeItemRemoved);
        }

        /// <summary>
        /// Gets an entry from the cache with the specified key, or if the entry does not exist, inserts a
        /// cache entry into the cache by using a key, a value and sliding expiration and returns it.
        /// </summary>
        /// <typeparam name="T">The type of the cache entry value.</typeparam>
        /// <param name="key">A unique identifier for the cache entry to insert.</param>
        /// <param name="value">The data for the cache entry.</param>
        /// <param name="slidingExpiration">The sliding expiration time, after which the cache entry will expire.</param>
        /// <param name="afterItemRemoved">The action to perform after the cache entry has been removed.</param>
        /// <param name="beforeItemRemoved">The action to perform before the cache entry has been removed.</param>
        /// <returns>A reference to the cache entry that is identified by key.</returns>
        public T GetOrAdd<T>(
            string key,
            Func<T> value,
            TimeSpan slidingExpiration,
            Action<string, T> afterItemRemoved = null,
            Action<string, T> beforeItemRemoved = null) where T : class
        {
            return this.GetOrAdd(key, value, null, slidingExpiration, afterItemRemoved, beforeItemRemoved);
        }

        /// <summary>
        /// Gets an entry from the cache with the specified key, or if the entry does not exist, inserts a
        /// cache entry into the cache by using a key, a value and no expiration and returns it.
        /// </summary>
        /// <typeparam name="T">The type of the cache entry value.</typeparam>
        /// <param name="key">A unique identifier for the cache entry to insert.</param>
        /// <param name="value">A function that asynchronously gets the data for the cache entry.</param>
        /// <param name="afterItemRemoved">The action to perform after the cache entry has been removed.</param>
        /// <param name="beforeItemRemoved">The action to perform before the cache entry has been removed.</param>
        /// <returns>A reference to the cache entry that is identified by key.</returns>
        public Task<T> GetOrAddAsync<T>(
            string key,
            Func<Task<T>> value,
            Action<string, T> afterItemRemoved = null,
            Action<string, T> beforeItemRemoved = null) where T : class
        {
            return this.GetOrAddAsync(key, value, null, null, afterItemRemoved, beforeItemRemoved);
        }

        /// <summary>
        /// Gets an entry from the cache with the specified key, or if the entry does not exist, inserts a
        /// cache entry into the cache by using a key, a value and absolute expiration and returns it.
        /// </summary>
        /// <typeparam name="T">The type of the cache entry value.</typeparam>
        /// <param name="key">A unique identifier for the cache entry to insert.</param>
        /// <param name="value">A function that asynchronously gets the data for the cache entry.</param>
        /// <param name="absoluteExpiration">The absolute expiration time, after which the cache entry will expire.</param>
        /// <param name="afterItemRemoved">The action to perform after the cache entry has been removed.</param>
        /// <param name="beforeItemRemoved">The action to perform before the cache entry has been removed.</param>
        /// <returns>A reference to the cache entry that is identified by key.</returns>
        public Task<T> GetOrAddAsync<T>(
            string key,
            Func<Task<T>> value,
            DateTimeOffset absoluteExpiration,
            Action<string, T> afterItemRemoved = null,
            Action<string, T> beforeItemRemoved = null) where T : class
        {
            return this.GetOrAddAsync(key, value, absoluteExpiration, null, afterItemRemoved, beforeItemRemoved);
        }

        /// <summary>
        /// Gets an entry from the cache with the specified key, or if the entry does not exist, inserts a
        /// cache entry into the cache by using a key, a value and sliding expiration and returns it.
        /// </summary>
        /// <typeparam name="T">The type of the cache entry value.</typeparam>
        /// <param name="key">A unique identifier for the cache entry to insert.</param>
        /// <param name="value">A function that asynchronously gets the data for the cache entry.</param>
        /// <param name="slidingExpiration">The sliding expiration time, after which the cache entry will expire.</param>
        /// <param name="afterItemRemoved">The action to perform after the cache entry has been removed.</param>
        /// <param name="beforeItemRemoved">The action to perform before the cache entry has been removed.</param>
        /// <returns>A reference to the cache entry that is identified by key.</returns>
        public Task<T> GetOrAddAsync<T>(
            string key,
            Func<Task<T>> value,
            TimeSpan slidingExpiration,
            Action<string, T> afterItemRemoved = null,
            Action<string, T> beforeItemRemoved = null) where T : class
        {
            return this.GetOrAddAsync(key, value, null, slidingExpiration, afterItemRemoved, beforeItemRemoved);
        }

        /// <summary>
        /// Update data using predicate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <param name="data"></param>
        /// <param name="predicate"></param>
        public void Update<T>(string cacheKey, T item, Func<T, bool> predicate)
        {
            try
            {
                var data = this.memoryCache.Get(cacheKey) as IEnumerable<T>;

                if(data == null)
                {
                    return;
                }

                var itemToUpdate = data.FirstOrDefault(predicate);

                if(itemToUpdate == null)
                {
                    return;
                }

                itemToUpdate = item;

                AddOrUpdate(cacheKey, data);
            }
            catch (Exception)
            {
                return;
            }
            
        }

        /// <summary>
        /// Removes a cache entry from the cache with the specified key.
        /// </summary>
        /// <param name="key">A unique identifier for the cache entry to remove.</param>
        /// <exception cref="System.ArgumentNullException">key is null.</exception>
        public void Remove(string key)
        {
            this.memoryCache.Remove(key);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets an entry from the cache with the specified key, or if the entry does not exist, inserts a
        /// cache entry into the cache by using a key, a value, a type of expiration and returns it.
        /// </summary>
        /// <typeparam name="T">The type of the cache entry value.</typeparam>
        /// <param name="key">A unique identifier for the cache entry to insert.</param>
        /// <param name="getValue">A function that gets the data for the cache entry.</param>
        /// <param name="absoluteExpiration">The absolute expiration time, after which the cache entry will expire.</param>
        /// <param name="slidingExpiration">The sliding expiration time, after which the cache entry will expire.</param>
        /// <param name="afterItemRemoved">The action to perform after the cache entry has been removed.</param>
        /// <param name="beforeItemRemoved">The action to perform before the cache entry has been removed.</param>
        /// <returns>A reference to the cache entry that is identified by key.</returns>
        private T GetOrAdd<T>(
            string key,
            Func<T> getValue,
            DateTimeOffset? absoluteExpiration,
            TimeSpan? slidingExpiration,
            Action<string, T> afterItemRemoved,
            Action<string, T> beforeItemRemoved) where T : class
        {
            T value = this.Get<T>(key);

            if (value == null)
            {
                value = getValue();
                this.AddOrUpdate(
                    key,
                    value,
                    absoluteExpiration,
                    slidingExpiration,
                    afterItemRemoved,
                    beforeItemRemoved);
            }

            return value;
        }

        /// <summary>
        /// Gets an entry from the cache with the specified key, or if the entry does not exist, inserts a
        /// cache entry into the cache by using a key, a value, a type of expiration and returns it.
        /// </summary>
        /// <typeparam name="T">The type of the cache entry value.</typeparam>
        /// <param name="key">A unique identifier for the cache entry to insert.</param>
        /// <param name="getValue">A function that asynchronously gets the data for the cache entry.</param>
        /// <param name="absoluteExpiration">The absolute expiration time, after which the cache entry will expire.</param>
        /// <param name="slidingExpiration">The sliding expiration time, after which the cache entry will expire.</param>
        /// <param name="afterItemRemoved">The action to perform after the cache entry has been removed.</param>
        /// <param name="beforeItemRemoved">The action to perform before the cache entry has been removed.</param>
        /// <returns>A reference to the cache entry that is identified by key.</returns>
        private async Task<T> GetOrAddAsync<T>(
            string key,
            Func<Task<T>> getValue,
            DateTimeOffset? absoluteExpiration,
            TimeSpan? slidingExpiration,
            Action<string, T> afterItemRemoved,
            Action<string, T> beforeItemRemoved) where T : class
        {
            T value = this.Get<T>(key);

            if (value == null)
            {
                value = await getValue();
                this.AddOrUpdate(
                    key,
                    value,
                    absoluteExpiration,
                    slidingExpiration,
                    afterItemRemoved,
                    beforeItemRemoved);
            }

            return value;
        }

        /// <summary>
        /// Inserts a cache entry into the cache by using a key, a value and an expiration type.
        /// </summary>
        /// <typeparam name="T">The type of the cache entry value.</typeparam>
        /// <param name="key">A unique identifier for the cache entry to insert.</param>
        /// <param name="value">The data for the cache entry.</param>
        /// <param name="absoluteExpiration">The absolute expiration time, after which the cache entry will expire.</param>
        /// <param name="slidingExpiration">The sliding expiration time, after which the cache entry will expire.</param>
        /// <param name="afterItemRemoved">The action to perform after the cache entry has been removed.</param>
        /// <param name="beforeItemRemoved">The action to perform before the cache entry has been removed.</param>
        private void AddOrUpdate<T>(
            string key,
            T value,
            DateTimeOffset? absoluteExpiration,
            TimeSpan? slidingExpiration,
            Action<string, T> afterItemRemoved,
            Action<string, T> beforeItemRemoved) where T : class
        {
            CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
            if (absoluteExpiration.HasValue)
            {
                cacheItemPolicy.AbsoluteExpiration = absoluteExpiration.Value;
            }
            if (slidingExpiration.HasValue)
            {
                cacheItemPolicy.SlidingExpiration = slidingExpiration.Value;
            }
            if (afterItemRemoved != null)
            {
                cacheItemPolicy.RemovedCallback = x => afterItemRemoved(
                    x.CacheItem.Key,
                    (T)x.CacheItem.Value);
            }
            if (beforeItemRemoved != null)
            {
                cacheItemPolicy.UpdateCallback = x => beforeItemRemoved(
                    x.UpdatedCacheItem.Key,
                    (T)x.UpdatedCacheItem.Value);
            }

            if (value != null)
            {
                this.memoryCache.Set(key, value, cacheItemPolicy);
            }
        }

        #endregion
    }
}