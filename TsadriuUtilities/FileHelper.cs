// <copyright file StringHelper.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>

using System;
using System.IO;
using TsadriuUtilitiesOld;

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
            return fileName.Split(".")[fileName.CharCount(".")];
        }

        /// <summary>
        /// Checks if a <paramref name="fullFileName"/> exists. If <paramref name="createFile"/> is true, it will create <paramref name="fullFileName"/> if the <paramref name="fullFileName"/> doesn't exist (Keep in mind that the path of <paramref name="fullFileName"/> must exist for <paramref name="createFile"/> to work).
        /// </summary>
        /// <param name="fullFileName">File name with the path included.</param>
        /// <param name="createFile">Create the file in case the <paramref name="fullFileName"/> doesn't exist. The path must exist beforehand for this to work.</param>
        /// <returns>True if the file exists. Otherwise false.</returns>
        public static bool Exist(string fullFileName, bool createFile = false)
        {
            if (DirectoryHelper.NotExist(fullFileName))
            {
                return false;
            }

            var fileName = Path.GetFileName(fullFileName);

            bool fileExists = File.Exists(fullFileName);

            if (fileExists)
            {
                return true;
            }

            if (createFile)
            {
                File.Create(fullFileName).Close();
                return true;
            }

            Console.WriteLine($"File '{fileName}' does not exist.");
            return false;
        }

        /// <summary>
        /// Checks if a <paramref name="fullFileName"/> does not exist. If <paramref name="createFile"/> is true, it will create <paramref name="fullFileName"/> if the <paramref name="fullFileName"/> doesn't exist (Keep in mind that the path of <paramref name="fullFileName"/> must exist for <paramref name="createFile"/> to work).
        /// </summary>
        /// <param name="fullFileName">File name with the path included.</param>
        /// <param name="createFile">Create the file in case the <paramref name="fullFileName"/> doesn't exist. The path must exist beforehand for this to work.</param>
        /// <returns>True if the file exists. Otherwise false.</returns>
        public static bool NotExist(string fullFileName, bool createFile = false)
        {
            return !Exist(fullFileName, createFile);
        }
    }
}