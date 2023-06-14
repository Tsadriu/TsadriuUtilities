// <copyright file StringSplitByEnum.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2023 (C) Tsadriu. All rights reserved.
// </copyright>

using System;

namespace TsadriuUtilities.Enums
{
    /// <summary>
    /// Enum to use when you're trying to split a <see cref="string"/>.
    /// </summary>
    public enum StringSplitByEnum
    {
        /// <summary>
        /// Carriage return character <b>\r</b>.
        /// </summary>
        CarriageReturn,
        
        /// <summary>
        /// Coma character <b>,</b>.
        /// </summary>
        Coma,

        /// <summary>
        /// Dash character <b>-</b>.
        /// </summary>
        Dash,

        /// <summary>
        /// Dot character <b>.</b>.
        /// </summary>
        Dot,

        /// <summary>
        /// Double quote character <b>"</b>.
        /// </summary>
        DoubleQuote,

        /// <summary>
        /// Environment new line character.<br/>
        /// This uses the <b><see cref="Environment.NewLine"/></b> property.
        /// </summary>
        EnvironmentNewLine,

        /// <summary>
        /// Equal character <b>=</b>.
        /// </summary>
        Equal,

        /// <summary>
        /// New line character <b>\n</b>.
        /// </summary>
        NewLine,

        /// <summary>
        /// Single quote character <b>'</b>.
        /// </summary>
        SingleQuote,

        /// <summary>
        /// Space character (0x20).
        /// </summary>
        Space,

        /// <summary>
        /// Underscore character <b>_</b>.
        /// </summary>
        Underscore,

        /// <summary>
        /// User defined case. Using this value will <b>allow the user</b> to specify the split type.
        /// </summary>
        UserDefined,
    }
}
