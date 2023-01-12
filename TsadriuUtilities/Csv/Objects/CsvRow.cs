// <copyright file CsvRow.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>

namespace TsadriuUtilities
{
    /// <summary>
    /// A class that holds the information of a csv row.
    /// </summary>
    public class CsvRow
    {
        /// <summary>
        /// Instantiates a new instance of <see cref="CsvRow"/>.
        /// </summary>
        /// <param name="rowContent">The content of the row.</param>
        public CsvRow(string rowContent = null)
        {
            Content = rowContent;
        }

        /// <summary>
        /// Gets or sets the content of the row.
        /// </summary>
        public string Content { get; set; }
    }
}