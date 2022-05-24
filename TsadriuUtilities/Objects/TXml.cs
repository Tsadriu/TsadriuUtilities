// <copyright file TXml.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsadriuUtilities.Objects
{
    /// <summary>
    /// A class that helps on storing xml data.
    /// </summary>
    public class TXml
    {
        public List<TXmlObject> XmlTags { get => throw new NotImplementedException("Method is still in development and is not ready"); set => throw new NotImplementedException("Method is still in development and is not ready"); }

        public static void ReadXml(string content)
        {
            throw new NotImplementedException("Method is still in development and is not ready");
            var test = content.GetTagValues("<", ">", true); //content.Split("\n"); 
            var tags = new List<TXmlTag>();
            string[] xmlTags = new string[] { "</", "/>", "<", ">" };

            for (int i = 53; i < test.Count - 1;)
            {
                if (test[i].Contains("xml version") || test[i].Contains("xsi=\"http"))
                {
                    i++;
                    continue;
                }

                var currentTag = test[i].Remove(xmlTags);
                var nextTag = test[i + 1].Remove(xmlTags);

                var currentTest = new TXmlTag() { TagStart = test[i], Children = GetChildren(currentTag, content).Children };
                i++;
                tags.Add(currentTest);
            }
        }

        public static TXmlTag GetChildren(string startTag, string text, TXmlTag child = null)
        {
            throw new NotImplementedException("Method is still in development and is not ready");
            var rawData = text.GetTagValue($"<{startTag}>", $"</{startTag}>");

            string[] xmlTags = new string[] { "</", "/>", "<", ">" };

            var children = rawData.GetTagValues("<", ">", true);

            child = new TXmlTag() { TagStart = $"<{startTag}>", TagEnd = $"</{startTag}>",  Children = new List<TXmlTag>() };

            for (int i = 0; i < children.Count - 1; i += 2)
            {
                var currentChild = children[i].Remove(xmlTags);
                var nextChild = children[i + 1].Remove(xmlTags);

                if (currentChild.Equals(nextChild))
                {
                    child.Children.Add(new TXmlTag() { TagStart = children[i] });
                }
                else
                {
                    child.Children.Add(GetChildren(currentChild, rawData, child));
                }
            }

            return child;
        }
    }
}
