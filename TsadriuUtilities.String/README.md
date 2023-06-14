# TsadriuUtilities.String
### _A small package that helps on manipulating and managing string types._

TsadriuUtilities.String is a small library that helps on manipulating and managing string types.
## > Features <

### StringHelper:
- **GetBetween(string text, string start, string end, StringComparison comparison, bool startEndIncluded)** + 1 overload:
    - Retrieves the substring between two specified strings within the given text, using the specified string comparison rules.
- **GetBetweenReverse(string text, string start, string end, StringComparison comparison, bool startEndIncluded)** + 1 overload:
    - Searches through the text, using the start as the start tag and then searches the text **backwards** until the end tag is found or until it reaches the end of the text.
- **GetManyBetween(string text, string start, string end, StringComparison comparison, bool startEndIncluded)** + 1 overload:
    - Retrieves multiple substrings from the specified **text** that are located between the specified start and end strings.
- **IsEmpty(string value)**:
    - Determines whether the specified string is empty, null or consists only of white-space characters.
- **IsNotEmpty(string value)**:
    - Determines whether the specified string is not empty, not null and contains at least one non-white-space character.
- **RemoveMany(string value, params string[] valuesToRemove)**:
    - Replaces multiple occurrences of strings specified in **valuesToRemove** with **string.Empty** in the **value** string.
- **TextCount(string value, string valueToCount)**:
    - Counts the number of occurrences of a specified **valueToCount** within the **value** string.
- **ContainsAll(string text, StringComparison comparison, param string[] values)** + 1 overload:
    - Checks whether a string contains all specified values, using the specified string comparison.
- **ContainsAny(string text, StringComparison comparison, param string[] values)** + 1 overload:
  - Checks whether a string contains any of the specified values, using the specified string comparison.
- **SplitBy(string value, StringSplitByEnum splitByEnum, bool keepSeparator, string? separator)**:
    - Splits the specified **value** string based on the specified **splitByEnum**.