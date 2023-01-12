// <copyright file CsvTable.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;

namespace TsadriuUtilities
{
    /// <summary>
    /// A class that holds the information of a csv column.
    /// </summary>
    public class CsvTable
    {
        private string originalFileContent;

        /// <summary>
        /// Gets or sets the columns of this <see cref="CsvTable"/>.
        /// </summary>
        public List<CsvColumn> Columns { get; set; }

        public CsvTable(string fullFilePath, string delimiter = ";")
        {
            ReadFromFile(fullFilePath, delimiter);
        }

        public void ReadFromFile(string fullFilePath, string delimiter = ";")
        {
            if (File.Exists(fullFilePath))
            {
                originalFileContent = File.ReadAllText(fullFilePath);
            }
        }

        public void ReadFromString(string csvContent, string delimiter = ";")
        {
            if (csvContent.IsNotEmpty())
            {
                originalFileContent = csvContent;
            }
        }

        public void ReadFromList(List<string> csvContent, string delimiter = ";")
        {

        }
    }
}