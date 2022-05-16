// <copyright file TXmlObject.cs of solution TsadriuUtilities of developer Tsadriu>
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
    public class TXmlObject
    {
        public string TagName { get; set; }

        public List<TXmlObject> TagChildren { get; set; }

        public object TagValue { get; set; }
    }
}
