﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsadriuUtilities
{
    /// <summary>
    /// A class that helps store data on the go.
    /// </summary>
    public class TTableColumn
    {
        /// <summary>
        /// Creates a new instace of <see cref="TTableColumn"/> (Tsadriu Table Column).
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        public TTableColumn(string columnName)
        {
            ColumnName = columnName;
            ColumnData = new List<object>();
        }

        /// <summary>
        /// The name of the column.
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// The data stored in the column.
        /// </summary>
        public List<object> ColumnData { get; set; }

        /// <summary>
        /// Adds <paramref name="values"/> into the <see cref="TTableColumn"/> as <see cref="object"/>.
        /// </summary>
        /// <param name="values">Values to store in the <see cref="TTableColumn"/>.</param>
        public void AddData(params object[] values)
        {
            foreach (var value in values)
            {
                ColumnData.Add(value);
            }
        }

        /// <summary>
        /// Checks through the <see cref="TTableColumn"/> for <paramref name="value"/>. Returns true if <paramref name="value"/> is found, otherwise false.
        /// </summary>
        /// <param name="value">Value to be checked.</param>
        /// <returns>True if the <paramref name="value"/> is found, otherwise false.</returns>
        public bool ExistsData(object value)
        {
            foreach (var columnData in ColumnData)
            {
                if (columnData.Equals(value))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Removes all instances of <paramref name="values"/>.
        /// </summary>
        /// <param name="values">Values to remove from the <see cref="TTableColumn"/>.</param>
        public void RemoveData(params object[] values)
        {
            for (int columnData = 0; columnData < ColumnData.Count; columnData++)
            {
                foreach (var value in values)
                {
                    if (ColumnData[columnData].Equals(value))
                    {
                        ColumnData.RemoveAt(columnData);
                        columnData--;
                    }
                }
            }
        }
    }
}
