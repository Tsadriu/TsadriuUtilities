// <copyright file DirectoryHelper.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>
using System;
using System.IO;

namespace TsadriuUtilities
{
    /// <summary>
    /// A class that helps on dealing with <see cref="Directory"/>.
    /// </summary>
    public static class DirectoryHelper
    {
        /// <summary>
        /// Checks if a <paramref name="path"/> exists. If <paramref name="createFolder"/> is true, it will create <paramref name="path"/> if the <paramref name="path"/> doesn't exist.
        /// </summary>
        /// <param name="path">Path.</param>
        /// <param name="createFolder">Create the folder in case the <paramref name="path"/> doesn't exist.</param>
        /// <returns>True if the path exists. Otherwise false.</returns>
        public static bool Exist(string path, bool createFolder = false)
        {
            // In case a path with a filename is passed.
            path = Path.GetDirectoryName(path);

            var pathExists = Directory.Exists(path);

            if (pathExists)
            {
                return true;
            }

            if (createFolder)
            {
                Directory.CreateDirectory(path);
                return true;
            }

            Console.WriteLine($"Path '{path}' does not exist.");
            return false;
        }

        /// <summary>
        /// Checks if a <paramref name="path"/> does not exist. If <paramref name="createFolder"/> is true, it will create <paramref name="path"/> if the <paramref name="path"/> doesn't exist.
        /// </summary>
        /// <param name="path">Path.</param>
        /// <param name="createFolder">Create the folder in case the <paramref name="path"/> doesn't exist.</param>
        /// <returns>True if the path does not exist. Otherwise false.</returns>
        public static bool NotExist(string path, bool createFolder = false)
        {
            return !Exist(path, createFolder);
        }
    }
}