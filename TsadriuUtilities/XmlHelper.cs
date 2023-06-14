// <copyright file XmlHelper.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>
using System.Linq;
using TsadriuUtilitiesOld;

namespace TsadriuUtilities
{
    /// <summary>
    /// A class that helps on dealing with xml.
    /// </summary>
    public static class XmlHelper
    {
        /// <summary>
        /// Searches through the <paramref name="xml"/>, removing empty tags that have the format of <![CDATA[<EmptyTag/>]]>.
        /// </summary>
        /// <param name="xml">The xml text.</param>
        /// <returns>The xml where the empty tags are removed.</returns>
        public static string RemoveEmptyTags(this string xml)
        {
            return xml.Remove(xml.GetMultipleBetween("<", "/>", true).Where(x => !x.Contains("=\"")).ToArray());
        }
    }
}
