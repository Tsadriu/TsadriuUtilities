// <copyright file TTable.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TsadriuUtilities
{
    /// <summary>
    /// A class that helps store data on the go.
    /// </summary>
    public class TTable
    {
        /// <summary>
        /// Creates a new instace of <see cref="TTable"/>.
        /// </summary>
        public TTable()
        {
            StartUp();
        }

        /// <summary>
        /// Adds a new <see cref="TTableColumn"/> in the <see cref="TTable"/>.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        public void AddColumn(params string[] columnName)
        {
            foreach (var column in columnName)
            {
                AddColumn(new TTableColumn(column));
            }
        }

        /// <summary>
        /// Adds a new <see cref="TTableColumn"/> in the <see cref="TTable"/>.
        /// </summary>
        /// <param name="tableColumn">Instance of <see cref="TTableColumn"/>.</param>
        public void AddColumn(params TTableColumn[] tableColumn)
        {
            foreach (var column in tableColumn)
            {
                ColumnList.Add(column);
            }
        }

        /// <summary>
        /// Adds <paramref name="values"/> into the <see cref="TTableColumn"/> as <see cref="object"/>.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="values">Values to store in the <see cref="TTableColumn"/>.</param>
        public void AddData(string columnName, params object[] values)
        {
            var exists = ColumnList.Any(x => x.ColumnName.Equals(columnName, StringComparison.OrdinalIgnoreCase));

            if (exists)
            {
                ColumnList.Where(x => x.ColumnName.Equals(columnName, StringComparison.OrdinalIgnoreCase)).First().AddData(values);
            }
            else
            {
                Console.WriteLine($"Column '{columnName}' is not present in the table. Please ensure that you wrote the correct name of the column.");
            }
        }

        /// <summary>
        /// Adds <paramref name="values"/> into the <see cref="TTableColumn"/> as <see cref="object"/>.
        /// </summary>
        /// <param name="tableColumn"><see cref="TTableColumn"/> instance.</param>
        /// <param name="values">Values to store in the <see cref="TTableColumn"/>.</param>
        public void AddData(TTableColumn tableColumn, params object[] values)
        {
            if (tableColumn != null)
            {
                tableColumn.AddData(values);
            }
        }

        /// <summary>
        /// Checks through the <see cref="TTableColumn"/> for <paramref name="value"/>. Returns true if <paramref name="value"/> is found, otherwise false.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="value">Value to be checked.</param>
        /// <returns>True if the <paramref name="value"/> is found, otherwise false.</returns>
        public bool ExistsData(string columnName, object value)
        {
            var exists = ColumnList.Any(x => x.ColumnName.Equals(columnName, StringComparison.OrdinalIgnoreCase));

            if (exists)
            {
                return ColumnList.Where(x => x.ColumnName.Equals(columnName, StringComparison.OrdinalIgnoreCase)).First().ExistsData(value);
            }
            else
            {
                Console.WriteLine($"Column '{columnName}' is not present in the table. Please ensure that you wrote the correct name of the column.");
            }

            return false;
        }

        /// <summary>
        /// Checks through the <see cref="TTableColumn"/> for <paramref name="value"/>. Returns true if <paramref name="value"/> is found, otherwise false.
        /// </summary>
        /// <param name="tableColumn">Instance of <see cref="TTableColumn"/>.</param>
        /// <param name="value">Value to be checked.</param>
        /// <returns>True if the <paramref name="value"/> is found, otherwise false.</returns>
        public bool ExistsData(TTableColumn tableColumn, object value)
        {
            return tableColumn.ExistsData(value);
        }

        /// <summary>
        /// If the <paramref name="columnName"/> exists, returns all the data present in the <see cref="TTableColumn"/>.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>If the <see cref="TTableColumn"/> exists, returns a List of <see cref="object"/> containing the data. Otherwise returns an empty list. </returns>
        public List<object> GetData(string columnName)
        {
            var data = new List<object>();

            foreach (var column in ColumnList)
            {
                if (column.ColumnName.Equals(columnName, StringComparison.OrdinalIgnoreCase))
                {
                    data.AddRange(column.ColumnData);
                }
            }

            return data;
        }

        /// <summary>
        /// Removes all instances of <paramref name="valuesToRemove"/>.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="valuesToRemove">Values to remove from the <see cref="TTableColumn"/>.</param>
        public void RemoveData(string columnName, params object[] valuesToRemove)
        {
            var exists = ColumnList.Any(x => x.ColumnName.Equals(columnName, StringComparison.OrdinalIgnoreCase));

            if (exists)
            {
                ColumnList.Where(x => x.ColumnName.Equals(columnName, StringComparison.OrdinalIgnoreCase)).First().RemoveData(valuesToRemove);
            }
            else
            {
                Console.WriteLine($"Column '{columnName}' is not present in the table. Please ensure that you wrote the correct name of the column.");
            }
        }

        /// <summary>
        /// Removes all instances of <paramref name="valuesToRemove"/>.
        /// </summary>
        /// <param name="tableColumn"><see cref="TTableColumn"/> instance.</param>
        /// <param name="valuesToRemove">Values to remove from the <see cref="TTableColumn"/>.</param>
        public void RemoveData(TTableColumn tableColumn, params object[] valuesToRemove)
        {
            if (tableColumn != null)
            {
                tableColumn.RemoveData(valuesToRemove);
            }
        }

        /// <summary>
        /// Transform the <see cref="TTable"/> into a parseable .csv file.
        /// </summary>
        /// <param name="addHeader">If true, the generated .csv file will have a header. If false, the generated .csv file will have no header. <see cref="TTableColumn.ColumnName"/> will be used as a header.</param>
        /// <param name="separator">Separator of the csv. Default uses ;</param>
        /// <returns>List of <see cref="TTable"/> that has been parsed to a List of <see cref="string"/> as a csv.</returns>
        public List<string> TableToCsv(bool addHeader = true, string separator = ";")
        {
            var content = new List<string>();
            string header = GetHeadersAsString(ColumnList, separator);

            if (addHeader)
            {
                content.Add(header);
            }

            var maxRow = GetHighestColumnDataCount();

            for (int currentRow = 0; currentRow < maxRow; currentRow++)
            {
                string rowData = string.Empty;

                for (int currentColumn = 0; currentColumn < ColumnList.Count; currentColumn++)
                {
                    if (currentRow >= ColumnList[currentColumn].ColumnData.Count)
                    {
                        rowData = rowData.PadRight(rowData.Length + 1, CharHelper.StringToChar(separator));
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(rowData))
                        {
                            rowData = ColumnList[currentColumn].ColumnData[currentRow].ToString();
                        }
                        else
                        {
                            rowData = string.Join(separator, rowData, ColumnList[currentColumn].ColumnData[currentRow]);
                        }
                    }
                }
                content.Add(rowData);
            }

            return content;
        }

        /// <summary>
        /// Transforms a .csv file into a <see cref="TTable"/>.
        /// </summary>
        /// <param name="fullFileName">File name of the file, including its' path.</param>
        /// <param name="separator">Separator of the csv. Default uses ;</param>
        /// <returns>Instance of <see cref="TTable"/> with the data of <paramref name="fullFileName"/>.</returns>
        public void CsvToTable(string fullFileName, string separator = ";")
        {
            if (DirectoryHelper.NotExist(fullFileName))
            {
                return;
            }

            if (FileHelper.NotExist(fullFileName))
            {
                return;
            }

            var fileRows = ListHelper.ArrayToList(File.ReadAllLines(fullFileName));

            if (fileRows.Count == 0)
            {
                return;
            }

            AddColumn(fileRows[0].Split(separator));
            
            for (int dataIndex = 1; dataIndex < fileRows.Count; dataIndex++)
            {
                for (int columnIndex = 0; columnIndex < ColumnList.Count; columnIndex++)
                {
                    AddData(ColumnList[columnIndex].ColumnName, fileRows[dataIndex].Split(separator)[columnIndex]);
                }
            }
        }

        /// <summary>
        /// Checks through the List of <see cref="ColumnList"/> and returns the <see cref="TTableColumn.ColumnData"/> with the highest Count.
        /// </summary>
        /// <returns>Returns the <see cref="TTableColumn.ColumnData"/> with the highest Count.</returns>
        private int GetHighestColumnDataCount()
        {
            if (ColumnList.Count == 0)
            {
                return 0;
            }
            int highestCount = ColumnList[0].ColumnData.Count;

            for (int i = 0; i < ColumnList.Count; i++)
            {
                if (highestCount < ColumnList[i].ColumnData.Count)
                {
                    highestCount = ColumnList[i].ColumnData.Count;
                }
            }

            return highestCount;
        }

        /// <summary>
        /// Returns the headers of the <see cref="TTable"/> as a <see cref="string"/>.
        /// </summary>
        /// <param name="columns">The list of <see cref="TTableColumn"/> (usually found in object <see cref="ColumnList"/>).</param>
        /// <param name="separator">The desired separator. Default uses ;</param>
        /// <returns>Headers of the columns in a <see cref="string"/>.</returns>
        private string GetHeadersAsString(List<TTableColumn> columns, string separator = ";")
        {
            string header = string.Empty;

            for (int i = 0; i < columns.Count; i++)
            {
                header += ColumnList[i].ColumnName;

                if (i + 1 < ColumnList.Count)
                {
                    header += separator;
                }
            }

            return header;
        }

        private List<TTableColumn> ColumnList { get; set; }

        /// <summary>
        /// Starts up the List of <see cref="TTableColumn"/>.
        /// </summary>
        private void StartUp()
        {
            ColumnList = new List<TTableColumn>();
        }
    }
}
