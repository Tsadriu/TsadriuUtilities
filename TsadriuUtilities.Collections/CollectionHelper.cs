namespace TsadriuUtilities.Collections
{
    /// <summary>
    /// Provides utility methods for collection processing.
    /// </summary>
    public static class CollectionHelper
    {
        /// <summary>
        /// Checks if the given collection contains ALL of the specified items.
        /// </summary>
        /// <typeparam name="T">The type of items in the collection.</typeparam>
        /// <param name="collection">The collection to check.</param>
        /// <param name="items">The items to look for within the collection.</param>
        /// <returns>True if the collection contains all the specified items. False otherwise.</returns>
        public static bool ContainsAll<T>(this IEnumerable<T> collection, params T[] items)
        {
            var hashSet = new HashSet<T>(collection);
            return items.All(hashSet.Contains);
        }

        /// <summary>
        /// Checks if the given collection contains ANY of the specified items.
        /// </summary>
        /// <typeparam name="T">The type of items in the collection.</typeparam>
        /// <param name="collection">The collection to check.</param>
        /// <param name="items">The items to look for within the collection.</param>
        /// <returns>True if the collection contains any of the specified items. False otherwise.</returns>
        public static bool ContainsAny<T>(this IEnumerable<T> collection, params T[] items)
        {
            var hashSet = new HashSet<T>(collection);
            return items.Any(hashSet.Contains);
        }
    }
}
