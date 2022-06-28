// <copyright file SearchType.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>

namespace TsadriuUtilities.Enums.BoolHelper
{
    /// <summary>
    /// Enum to use when you're trying to search for a <see cref="string"/>.
    /// </summary>
    public enum SearchType
    {
        /// <summary>
        /// Will search if the <see cref="string"/> you're searching for is inside of the text.
        /// </summary>
        Contains,

        /// <summary>
        /// Will search if the <see cref="string"/> you're searching for is equal to the text.
        /// </summary>
        Equals
    }
}
