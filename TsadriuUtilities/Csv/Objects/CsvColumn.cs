// <copyright file CsvColumn.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using TsadriuUtilities.Csv.Enum;

namespace TsadriuUtilities
{
    /// <summary>
    /// A class that holds the information of a csv column.
    /// </summary>
    public class CsvColumn
    {
        /// <summary>
        /// Instantiates a new instance of <see cref="CsvColumn"/>.
        /// </summary>
        /// <param name="columnName">The column name.</param>
        public CsvColumn(string columnName = null)
        {
            Name = columnName;
        }

        /// <summary>
        /// Gets or sets the name of the column.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the rows in the colum.
        /// </summary>
        public List<CsvRow> Rows { get; set; }

        /// <summary>
        /// Add a row in the <see cref="Rows"/> for this column.
        /// </summary>
        /// <param name="rowsToAdd">Rows to add to this column.</param>
        public void AddRow(params string[] rowsToAdd)
        {
            foreach (string row in rowsToAdd)
            {
                Rows.Add(new CsvRow(row));
            }
        }

        public void SortRows(SortType sortingType = SortType.Ascending)
        {
            if (sortingType == SortType.Ascending)
            {
                Rows.Sort();
            }
            else
            {
                Rows.Reverse();
            }
        }

        /// <summary>
        /// Iterates through <see cref="Rows"/>, searching for the row that contains all <paramref name="values"/>.
        /// </summary>
        /// <param name="values">The values to search on the <see cref="Rows"/>.</param>
        /// <returns>The index of the row that contains all <paramref name="values"/>. If no row is found, it returns <b>-1</b>.</returns>
        public int GetIndexOfRowContaining(params string[] values)
        {
            for (int i = 0; i < Rows.Count; i++)
            {
                if (Rows[i].Content.AndContains(StringComparison.OrdinalIgnoreCase, values))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}