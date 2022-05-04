// <copyright file StringHelper.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>

namespace TsadriuUtilities
{
    /// <summary>
    /// A class that helps on dealing with <see cref="System.IO.File"/>.
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// Returns the extention of <paramref name="fileName"/>. If <paramref name="fileName"/> has multiple extentions (Example: filename.txt.zip), it will return the last extention.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <returns>Returns the extention of <paramref name="fileName"/>.</returns>
        public static string GetFileExtention(string fileName)
        {
            return fileName.Split(".")[StringHelper.CharCount(fileName, ".")];
        }
    }
}