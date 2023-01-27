// <copyright file SearchType.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>

using System;

namespace TsadriuUtilities.Enums.StringHelper
{
    /// <summary>
    /// Enum to use when you're trying to split a <see cref="string"/>.
    /// </summary>
    public enum SplitType
    {
        /// <summary>
        /// Simple carriage return character <b>\r</b>.
        /// </summary>
        CarriageReturn,
        
        /// <summary>
        /// Simple dash character <b>-</b>.
        /// </summary>
        Dash,
        
        /// <summary>
        /// Simple double quote character <b>"</b>.
        /// </summary>
        DoubleQuote,
        
        /// <summary>
        /// Environment new line character.<br/>
        /// This uses the <b><see cref="Environment.NewLine"/></b> property.
        /// </summary>
        EnvironmentNewLine,
        
        /// <summary>
        /// Simple equal character <b>=</b>.
        /// </summary>
        Equal,
        
        /// <summary>
        /// Simple new line character <b>\n</b>.
        /// </summary>
        NewLine,
        
        /// <summary>
        /// Simple single quote character <b>'</b>.
        /// </summary>
        SingleQuote,

        /// <summary>
        /// Simple space character (0x20).
        /// </summary>
        Space,
        
        /// <summary>
        /// Simple underscore character <b>_</b>.
        /// </summary>
        Underscore,
        
        /// <summary>
        /// User defined case. Using this value will <b>allow the user</b> to specify the split type.
        /// </summary>
        UserDefined,
    }
}
