// <copyright file Table.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Linq;

namespace TsadriuUtilities.Objects
{
    /// <summary>
    /// A class that helps store data on the go.
    /// </summary>
    public class Table
    {
        /// <summary>
        /// Creates a new instace of <see cref="Table"/>.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="columnDescription">Description of the column.</param>
        public Table(string columnName, string columnDescription = null)
        {
            StartUp();
            Column.Add(new TableColumn(columnName, columnDescription));
        }

        /// <summary>
        /// Adds a new <see cref="TableColumn"/> in the <see cref="Table"/>.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="columnDescription">Description of the column.</param>
        public void AddColumn(string columnName, string columnDescription = null)
        {
            AddColumn(new TableColumn(columnName, columnDescription));
        }

        /// <summary>
        /// Adds a new <see cref="TableColumn"/> in the <see cref="Table"/>.
        /// </summary>
        /// <param name="tableColumn">Instance of <see cref="TableColumn"/>.</param>
        public void AddColumn(TableColumn tableColumn)
        {
            Column.Add(tableColumn);
        }

        /// <summary>
        /// Adds <paramref name="values"/> into the <see cref="TableColumn"/> as <see cref="object"/>.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="values">Values to store in the <see cref="TableColumn"/>.</param>
        public void AddData(string columnName, params object[] values)
        {
            var exists = Column.Any(x => x.ColumnName.Equals(columnName, StringComparison.OrdinalIgnoreCase));

            if (exists)
            {
                Column.Where(x => x.ColumnName.Equals(columnName, StringComparison.OrdinalIgnoreCase)).First().AddData(values);
            }
            else
            {
                Console.WriteLine($"Column '{columnName}' is not present in the table. Please ensure that you wrote the correct name of the column.");
            }
        }

        /// <summary>
        /// Adds <paramref name="values"/> into the <see cref="TableColumn"/> as <see cref="object"/>.
        /// </summary>
        /// <param name="tableColumn"><see cref="TableColumn"/> instance.</param>
        /// <param name="values">Values to store in the <see cref="TableColumn"/>.</param>
        public void AddData(TableColumn tableColumn, params object[] values)
        {
            if (tableColumn != null)
            {
                tableColumn.AddData(values);
            }
        }

        /// <summary>
        /// Checks through the <see cref="TableColumn"/> for <paramref name="value"/>. Returns true if <paramref name="value"/> is found, otherwise false.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="value">Value to be checked.</param>
        /// <returns>True if the <paramref name="value"/> is found, otherwise false.</returns>
        public bool ExistsData(string columnName, object value)
        {
            var exists = Column.Any(x => x.ColumnName.Equals(columnName, StringComparison.OrdinalIgnoreCase));

            if (exists)
            {
                return Column.Where(x => x.ColumnName.Equals(columnName, StringComparison.OrdinalIgnoreCase)).First().ExistsData(value);
            }
            else
            {
                Console.WriteLine($"Column '{columnName}' is not present in the table. Please ensure that you wrote the correct name of the column.");
            }

            return false;
        }

        /// <summary>
        /// Checks through the <see cref="TableColumn"/> for <paramref name="value"/>. Returns true if <paramref name="value"/> is found, otherwise false.
        /// </summary>
        /// <param name="tableColumn">Instance of <see cref="TableColumn"/>.</param>
        /// <param name="value">Value to be checked.</param>
        /// <returns>True if the <paramref name="value"/> is found, otherwise false.</returns>
        public bool ExistsData(TableColumn tableColumn, object value)
        {
            return tableColumn.ExistsData(tableColumn);
        }

        /// <summary>
        /// Removes all instances of <paramref name="valuesToRemove"/>.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="valuesToRemove">Values to remove from the <see cref="TableColumn"/>.</param>
        public void RemoveData(string columnName, params object[] valuesToRemove)
        {
            var exists = Column.Any(x => x.ColumnName.Equals(columnName, StringComparison.OrdinalIgnoreCase));

            if (exists)
            {
                Column.Where(x => x.ColumnName.Equals(columnName, StringComparison.OrdinalIgnoreCase)).First().RemoveData(valuesToRemove);
            }
            else
            {
                Console.WriteLine($"Column '{columnName}' is not present in the table. Please ensure that you wrote the correct name of the column.");
            }
        }

        /// <summary>
        /// Removes all instances of <paramref name="valuesToRemove"/>.
        /// </summary>
        /// <param name="tableColumn"><see cref="TableColumn"/> instance.</param>
        /// <param name="valuesToRemove">Values to remove from the <see cref="TableColumn"/>.</param>
        public void RemoveData(TableColumn tableColumn, params object[] valuesToRemove)
        {
            if (tableColumn != null)
            {
                tableColumn.RemoveData(valuesToRemove);
            }
        }

        /// <summary>
        /// Transform the <see cref="Table"/> into a parseable .csv file.
        /// </summary>
        /// <param name="separator">Separator of the csv. Default: ;</param>
        /// <returns>List of <see cref="Table"/> that has been parsed to a List of <see cref="string"/> as a csv.</returns>
        public List<string> TableToCsv(string separator = ";")
        {
            throw new NotImplementedException("Not yet implemented.");
            string header = "";

            foreach (var column in Column)
            {
            }

            return new List<string>();
        }

        private List<TableColumn> Column { get; set; }

        /// <summary>
        /// Starts up the List of <see cref="TableColumn"/>.
        /// </summary>
        private void StartUp()
        {
            Column = new List<TableColumn>();
        }
    }
}
