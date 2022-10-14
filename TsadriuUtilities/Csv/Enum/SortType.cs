// <copyright file SortType.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>

namespace TsadriuUtilities.Csv.Enum
{
    /// <summary>
    /// Enum to use when you're trying to order a <see cref="CsvColumn"/>.
    /// </summary>
    public enum SortType
    {
        /// <summary>
        /// Ascending order type. A -> B -> C and so on.
        /// </summary>
        Ascending,

        /// <summary>
        /// Descending order type. C -> B -> A and so on.
        /// </summary>
        Descending,
    }
}
