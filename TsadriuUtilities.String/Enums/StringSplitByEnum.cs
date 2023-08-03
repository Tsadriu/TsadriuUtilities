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
        [Obsolete("Please use a more specific type, such as NewLineMacOs, NewLineUnix or NewLineWindows. This will be removed in the next update.")]
        EnvironmentNewLine,

        /// <summary>
        /// Equal character <b>=</b>.
        /// </summary>
        Equal,

        /// <summary>
        /// New line character <b>\n</b>.
        /// </summary>
        [Obsolete("Please use a more specific type, such as NewLineMacOs, NewLineUnix or NewLineWindows. This will be removed in the next update.")]
        NewLine,

        /// <summary>
        /// New line character that is used in old Mac OS operative systems \r.
        /// </summary>
        /// <remarks>Uses a carriage return character, \r.</remarks>
        NewLineMacOs,

        /// <summary>
        /// New line character that is used in non-Unix platforms.
        /// </summary>
        /// <remarks>Uses an end of line character, \r\n.</remarks>
        NewLineNonUnix,

        /// <summary>
        /// New line character that is used in Unix platforms.
        /// </summary>
        /// <remarks>Uses a line feed character, \n.</remarks>
        NewLineUnix,

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
