// <copyright file TXmlTag.cs of solution TsadriuUtilities of developer Tsadriu>
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
    public class TXmlTag
    {
        public bool IsParent { get; set; }
        public List<TXmlTag> Children { get; set; }
        public string TagStart { get; set; }

        public string TagEnd { get; set; }

        public int TagStartIndex { get; set; }

        public int TagEndIndex { get; set; }
    }
}
