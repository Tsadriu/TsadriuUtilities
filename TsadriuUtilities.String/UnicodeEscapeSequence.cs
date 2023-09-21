using System;
using System.Collections.Generic;
using System.Linq;
using TsadriuUtilities.Enums;

namespace TsadriuUtilities
{
    /// <summary>
    /// Represents a Unicode escape sequence.
    /// </summary>
    public class UnicodeEscapeSequence : ICloneable
    {
        /// <summary>
        /// Gets or sets the enum value of the Unicode escape sequence.
        /// </summary>
        public StringUnicodeEscapeSequenceEnum UnicodeEscapeSequenceEnum { get; set; }

        /// <summary>
        /// Gets or sets the Unicode escape sequence string.
        /// </summary>
        public string EscapeSequence { get; set; } = null!;

        /// <summary>
        /// Gets or sets the string to replace the Unicode escape sequence to.
        /// </summary>
        public string ReplaceTo { get; set; } = string.Empty;

        /// <inheritdoc />
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// The private variable to store the default escape sequences.
        /// </summary>
        private static IReadOnlyList<UnicodeEscapeSequence>? _defaultEscapeSequences;

        /// <summary>
        /// Gets the default list of Unicode escape sequences.
        /// </summary>
        /// <returns>A Clone of the default list of Unicode escape sequences.</returns>
        public static IReadOnlyList<UnicodeEscapeSequence> GetDefaultUnicodeEscapeSequences()
        {
            _defaultEscapeSequences ??= new List<UnicodeEscapeSequence>
            {
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.NUL,
                    EscapeSequence = "\u0000", // NUL (null)
                },
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.SOH,
                    EscapeSequence = "\u0001", // SOH
                },
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.STX,
                    EscapeSequence = "\u0002", // STX (start of text)
                },
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.ETX,
                    EscapeSequence = "\u0003", // ETX (end of text)
                },
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.EOT,
                    EscapeSequence = "\u0004", // EOT (end of transmission)
                },

                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.ENQ,
                    EscapeSequence = "\u0005", // EOT (end of transmission)
                },

                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.ACK,
                    EscapeSequence = "\u0006", // ACK (acknowledge)
                },

                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.BEL,
                    EscapeSequence = "\u0007", // BEL (bell)
                },

                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.BS,
                    EscapeSequence = "\u0008", // BS (backspace)
                },

                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.TAB,
                    EscapeSequence = "\u0009", // TAB (horizontal tab)
                },

                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.LF,
                    EscapeSequence = "\u000A", // LF (NL line feed, new line)
                },

                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.VT,
                    EscapeSequence = "\u000B", // VT (vertical tab)
                },

                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.FF,
                    EscapeSequence = "\u000C", // FF (NP form feed, new page)
                },

                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.CR,
                    EscapeSequence = "\u000D", // CR (carriage return)
                },

                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.SO,
                    EscapeSequence = "\u000E", // SO (shift out)
                },

                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.SI,
                    EscapeSequence = "\u000F", // SI (shift in)
                },

                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.DLE,
                    EscapeSequence = "\u0010", // DLE (data link escape)
                },

                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.DC1,
                    EscapeSequence = "\u0011", // DC1 (device control 1)
                },

                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.DC2,
                    EscapeSequence = "\u0012", // DC2 (device control 2)
                },

                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.DC3,
                    EscapeSequence = "\u0013", // DC3 (device control 3)
                },

                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.DC4,
                    EscapeSequence = "\u0014", // DC4 (device control 4)
                },

                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.NAK,
                    EscapeSequence = "\u0015", // NAK (negative acknowledge)
                },

                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.SYN,
                    EscapeSequence = "\u0016", // SYN (synchronous idle)
                },

                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.ETB,
                    EscapeSequence = "\u0017", // ETB (end of trans. block)
                },

                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.CAN,
                    EscapeSequence = "\u0018", // CAN (cancel)
                },

                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.EM,
                    EscapeSequence = "\u0019", // EM (end of medium)
                },

                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.SUB,
                    EscapeSequence = "\u001A", // SUB (substitute)
                },

                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.ESC,
                    EscapeSequence = "\u001B", // ESC (escape)
                },

                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.FS,
                    EscapeSequence = "\u001C", // FS (file separator)
                },

                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.GS,
                    EscapeSequence = "\u001D", // GS (group separator)
                },

                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.RS,
                    EscapeSequence = "\u001E", // RS (record separator)
                },

                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.US,
                    EscapeSequence = "\u001F", // US (unit separator)
                },
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.DEL,
                    EscapeSequence = "\u007F", // DEL
                },
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.NBSP,
                    EscapeSequence = "\u00A0", // NBSP
                },
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.A_Upper_Grave,
                    EscapeSequence = "\u00C0", // À
                    ReplaceTo = "A",
                },
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.A_Upper_Acute,
                    EscapeSequence = "\u00C1",
                    ReplaceTo = "A",
                }, // Á
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.A_Upper_Circumflex,
                    EscapeSequence = "\u00C2",
                    ReplaceTo = "A",
                }, // Â
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.A_Upper_Tilde,
                    EscapeSequence = "\u00C3",
                    ReplaceTo = "A",
                }, // Ã
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.A_Upper_Dieres,
                    EscapeSequence = "\u00C4",
                    ReplaceTo = "A",
                }, // Ä
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.A_Upper_Ring,
                    EscapeSequence = "\u00C5",
                    ReplaceTo = "A",
                }, // Å
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.C_Upper_Cedilla,
                    EscapeSequence = "\u00C7",
                    ReplaceTo = "Ç",
                }, // Ç
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.E_Upper_Grave,
                    EscapeSequence = "\u00C8",
                    ReplaceTo = "E",
                }, // È
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.E_Upper_Acute,
                    EscapeSequence = "\u00C9",
                    ReplaceTo = "E",
                }, // É
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.E_Upper_Circumflex,
                    EscapeSequence = "\u00CA",
                    ReplaceTo = "E",
                }, // Ê
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.E_Upper_Dieres,
                    EscapeSequence = "\u00CB",
                    ReplaceTo = "E",
                }, // Ë
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.I_Upper_Grave,
                    EscapeSequence = "\u00CC",
                    ReplaceTo = "I",
                }, // Ì
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.I_Upper_Acute,
                    EscapeSequence = "\u00CD",
                    ReplaceTo = "I",
                }, // Í
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.I_Upper_Circumflex,
                    EscapeSequence = "\u00CE",
                    ReplaceTo = "I",
                }, // Î
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.I_Upper_Dieres,
                    EscapeSequence = "\u00CF",
                    ReplaceTo = "I",
                }, // Ï
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.O_Upper_Grave,
                    EscapeSequence = "\u00D2",
                    ReplaceTo = "O",
                }, // Ò
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.O_Upper_Acute,
                    EscapeSequence = "\u00D3",
                    ReplaceTo = "O",
                }, // Ó
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.O_Upper_Circumflex,
                    EscapeSequence = "\u00D4",
                    ReplaceTo = "O",
                }, // Ô
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.O_Upper_Tilde,
                    EscapeSequence = "\u00D5",
                    ReplaceTo = "O",
                }, // Õ
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.O_Upper_Dieres,
                    EscapeSequence = "\u00D6",
                    ReplaceTo = "O",
                }, // Ö
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.U_Upper_Grave,
                    EscapeSequence = "\u00D9",
                    ReplaceTo = "U",
                }, // Ù
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.U_Upper_Acute,
                    EscapeSequence = "\u00DA",
                    ReplaceTo = "U",
                }, // Ú
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.U_Upper_Circumflex,
                    EscapeSequence = "\u00DB",
                    ReplaceTo = "U",
                }, // Û
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.U_Upper_Dieres,
                    EscapeSequence = "\u00DC",
                    ReplaceTo = "U",
                }, // Ü
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.A_Lower_Grave,
                    EscapeSequence = "\u00E0",
                    ReplaceTo = "a",
                }, // à
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.A_Lower_Acute,
                    EscapeSequence = "\u00E1",
                    ReplaceTo = "a",
                }, // á
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.A_Lower_Circumflex,
                    EscapeSequence = "\u00E2",
                    ReplaceTo = "a",
                }, // â
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.A_Lower_Tilde,
                    EscapeSequence = "\u00E3",
                    ReplaceTo = "a",
                }, // ã
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.A_Lower_Dieres,
                    EscapeSequence = "\u00E4",
                    ReplaceTo = "a",
                }, // ä
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.A_Lower_Ring,
                    EscapeSequence = "\u00E5",
                    ReplaceTo = "a",
                }, // å
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.C_Lower_Cedilla,
                    EscapeSequence = "\u00E7",
                    ReplaceTo = "ç",
                }, // ç
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.E_Lower_Grave,
                    EscapeSequence = "\u00E8",
                    ReplaceTo = "e",
                }, // è
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.E_Lower_Acute,
                    EscapeSequence = "\u00E9",
                    ReplaceTo = "e",
                }, // é
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.E_Lower_Circumflex,
                    EscapeSequence = "\u00EA",
                    ReplaceTo = "e",
                }, // ê
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.E_Lower_Dieres,
                    EscapeSequence = "\u00EB",
                    ReplaceTo = "e",
                }, // ë
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.I_Lower_Grave,
                    EscapeSequence = "\u00EC",
                    ReplaceTo = "i",
                }, // ì
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.I_Lower_Acute,
                    EscapeSequence = "\u00ED",
                    ReplaceTo = "i",
                }, // í
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.I_Lower_Circumflex,
                    EscapeSequence = "\u00EE",
                    ReplaceTo = "i",
                }, // î
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.I_Lower_Dieres,
                    EscapeSequence = "\u00EF",
                    ReplaceTo = "i",
                }, // ï
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.O_Lower_Grave,
                    EscapeSequence = "\u00F2",
                    ReplaceTo = "o",
                }, // ò
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.O_Lower_Acute,
                    EscapeSequence = "\u00F3",
                    ReplaceTo = "o",
                }, // ó
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.O_Lower_Circumflex,
                    EscapeSequence = "\u00F4",
                    ReplaceTo = "o",
                }, // ô
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.O_Lower_Tilde,
                    EscapeSequence = "\u00F5",
                    ReplaceTo = "o",
                }, // õ
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.O_Lower_Dieres,
                    EscapeSequence = "\u00F6",
                    ReplaceTo = "o",
                }, // ö
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.U_Lower_Grave,
                    EscapeSequence = "\u00F9",
                    ReplaceTo = "u",
                }, // ù
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.U_Lower_Acute,
                    EscapeSequence = "\u00FA",
                    ReplaceTo = "u",
                }, // ú
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.U_Lower_Circumflex,
                    EscapeSequence = "\u00FB",
                    ReplaceTo = "u",
                }, // û
                new UnicodeEscapeSequence
                {
                    UnicodeEscapeSequenceEnum = StringUnicodeEscapeSequenceEnum.U_Lower_Dieres,
                    EscapeSequence = "\u00FC", // ü
                    ReplaceTo = "u",
                },
            };

            return _defaultEscapeSequences.Select(x => (UnicodeEscapeSequence)x.Clone()).ToList();
        }
    }
}
