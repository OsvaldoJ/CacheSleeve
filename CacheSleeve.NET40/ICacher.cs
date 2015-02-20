﻿using System;
using System.Collections.Generic;
using CacheSleeve.Models;

namespace CacheSleeve
{
    /// <summary>
    /// Interface for cachers
    /// </summary>
    public interface ICacher
    {
        /// <summary>
        /// Fetchs an item from the cache.
        /// </summary>
        /// <typeparam name="T">The type of the item being fetched.</typeparam>
        /// <param name="key">The key of the item to retrieve.</param>
        /// <returns>
        /// The requested item or null.
        /// </returns>
        T Get<T>(string key);

        /// <summary>
        /// Insert an item into the cache.
        /// </summary>
        /// <typeparam name="T">The type of the item to be inserted.</typeparam>
        /// <param name="key">The key of the item being inserted.</param>
        /// <param name="value">The value of the item being inserted.</param>
        /// <param name="parentKey">The key of the item that this item is a child of.</param>
        /// <returns>A boolean indicating success or failure.</returns>
        /// <remarks>
        /// This will overwrite the value at the existing key if one exists.
        /// </remarks>
        bool Set<T>(string key, T value, string parentKey = null);

        /// <summary>
        /// Insert an item into the cache.
        /// </summary>
        /// <typeparam name="T">The type of the item to be inserted.</typeparam>
        /// <param name="key">The key of the item being inserted.</param>
        /// <param name="value">The value of the item being inserted.</param>
        /// <param name="expiresAt">The date and time that the item should expire.</param>
        /// <param name="parentKey">The key of the item that this item is a child of.</param>
        /// <returns>
        /// A boolean indicating success or failure.
        /// </returns>
        /// <remarks>
        /// This will overwrite the value at the existing key if one exists.
        /// </remarks>
        bool Set<T>(string key, T value, DateTime expiresAt, string parentKey = null);

        /// <summary>
        /// Insert an item into the cache.
        /// </summary>
        /// <typeparam name="T">The type of the item to be inserted.</typeparam>
        /// <param name="key">The key of the item being inserted.</param>
        /// <param name="value">The value of the item being inserted.</param>
        /// <param name="expiresIn">The time span that the item should be valid for.</param>
        /// <param name="parentKey">The key of the item that this item is a child of.</param>
        /// <returns>
        /// A boolean indicating success or failure.
        /// </returns>
        /// <remarks>
        /// This will overwrite the value at the existing key if one exists.
        /// </remarks>
        bool Set<T>(string key, T value, TimeSpan expiresIn, string parentKey = null);

        /// <summary>
        /// Deletes the specified item from the cache.
        /// </summary>
        /// <param name="key">The key of the item to delete.</param>
        /// <returns>
        /// A boolean indicating success or failure.
        /// </returns>
        bool Remove(string key);

        /// <summary>
        /// Clear the whole cache.
        /// </summary>
        void FlushAll();

        /// <summary>
        /// Returns a list of all available keys
        /// </summary>
        IEnumerable<Key> GetAllKeys();
    }
}