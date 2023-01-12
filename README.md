
# TsadriuUtilities
### _A package with utilities that are useful for web scraping, to make it easier and save a little bit of time._


TsadriuUtilities is a library that helps on dealing with
 - [Arrays](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/), [Chars](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/char), [Date and Time](https://docs.microsoft.com/en-us/dotnet/api/system.datetime.date?view=net-6.0), [Directories](https://docs.microsoft.com/en-us/dotnet/api/system.io.directory?view=net-6.0), [Files](https://docs.microsoft.com/en-us/dotnet/api/system.io.file?view=net-6.0), [Lists](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-6.0), [Numbers](https://docs.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/tutorials/numbers-in-csharp-local), [Strings](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0), 
[Generic types](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics) and more. I hope this package will make your coding easier and save you a bit of time. 

## > Features <
### ArrayHelper:
- **ToString\<T\>(T[], string separator)**:
    - Converts an `Array` into a single line of string. If the `separator` is not passed, it will separate by a space. Examples: ArrayToString(new int[] { 1, 3, 5 }) -> "1 3 5", ArrayToString(new string[] { "5", "2" }, "|") -> "5|2".
- **GenerateRandom\<T\>(T[] array, int min, int max)**:
    - Fills up the `array` with random numbers between `min` (default: 0, inclusive) and `max` (default: 100, inclusive).
- **GetValueLike(string[] stringArray, string value, StringComparison stringComparison)**
    - Iterates through the `stringArray`, returning the first item found that contains `value`.
- **GetValueContaining(string[] stringArray, StringComparison stringComparison, string[] values)**
    - Iterates through the `stringArray`, returning the first item found that contains all the `values`.
- **AddToElements(string[] stringArray, string startItemTag, string endItemTag)**
    - Iterates through the `stringArray`, adding `startItemTag` before the item and `endItemTag` after the item. Example: `startItemTag` is 'www.' and the items inside the `stringArray` are 'google.com'. This method will return the elements as 'www.google.com'.
- **RemoveFromElements(string[] stringArray, params string[] valuesToRemove)**
	- Returns an array where all occasions of `valuesToRemove` have been removed from the elements of the `stringArray`.
- **ReplaceFromElements(string[] stringArray, string oldValue, string newValue)**
    - Returns an array where all occasions of `oldValue` have been replaced by `newValue` from the elements of the `stringArray`.
- **GetBetween(string[] stringArray, string start, string end, bool startEndIncluded)**:
    - Iterates through the `stringArray`, returning the first instance where both `start` and `end` are found. If none of the indexes match `start` and `end`, a `string.Empty` is returned. Use `startEndIncluded` if you want to include `start` and `end` in the returning string.
- **GetMultipleBetween(string[] stringArray, string start, string end, bool startEndIncluded)**:
    - Searches through the `stringArray`, returning multiple instances found between `start` and `end`. Use `startEndIncluded` if you want to include `start` and `end` in the returning array.
- **KeepBetween(string[] stringArray, string start, string end, bool startEndIncluded, bool excludeEmptyIndexes)**:
    - Iterates through the `stringArray`, keeping the content between `start` and `end`. If `startEndIncluded` is enabled, the indexes will keep the `start` and `end`. If `excludeEmptyIndexes` is enabled, empty indexes will be removed from the array.
- **Exclude(string[] stringArray, string[] excludeStrings)**:
    - Iterates through the `stringArray`, excluding the indexes that contain `excludeStrings`.
- **AddRange\<T\>(T[] currentArray, T[] arrayToAdd)**:
    - Adds the `currentArray` into `arrayToAdd`.

### BoolHelper:
- **ToBool(string value, SearchType searchType, string[] trueValue, string[] falseValue)**:
	- Tries to parse the `value` into a `bool`. If the conversion was successfull, it will return `value` as `true` or `false` depending on where it was found (`trueValues`, `falseValues`). If `value` is not found in any of those, it'll launch an `ArgumentOutOfRangeException`.

### CharHelper:
- **ToChar(string value, int index)**:
    - Converts the `value` into a char. If the length of value is higher than 1, it will return the first character of value or, if `index` is passed, the character of the desired `index`. 

### DateTimeHelper:
- **ToDateTime(string dateAsString, string dateFormat, CultureInfo cultureInfo)**:
- **ToDateTime(string dateAsString, string[] dateFormats, CultureInfo cultureInfo)**:
    - Tries to convert a `date` from a string to a type of `DateTime`.
- **GetLastDayOfMonth(DateTime date)**:
    - Parses the `date` to return with the last day of the month.
- **SetDay(DateTime date, int day)**:
    - Sets the `day` in the `date`. In case the `day` is higher than the month's max days, it will be clamped.
- **SetMonth(DateTime date, int month)**:
    - Sets the `month` in the `date`. In case the `month` is higher than the year's maximum months, it will be clamped.
- **SetYear(DateTime date, int year)**:
    - Sets the `year` in the `date`.
- **RemoveDays(DateTime date, int days)**:
    - Removes a specified number of `days` from `date`.
- **RemoveMonths(DateTime date, int months)**:
    - Removes a specified number of `months` from `date`.
- **RemoveYears(DateTime date, int years)**:
    - Removes a specified number of `years` from `date`.

### DictionaryHelper:
- **ToDictionary\<TKey, TValue\>(List\<string\> list, string separator, bool invertKeyWithValue)**:
    - Iterates through each element of the `list` and splits it by `separator`, assigning `TKey` to everything that is before the `separator` and `TValue` to everything that is after the `separator`.
- **FlipKeyWithValue\<TKey, TValue\>(Dictionary\<TKey, TValue\> dictionary)**:
    - Returns the `dictionary` where the `TValue` is the key and `TKey` is the value.

### DirectoryHelper:
- **Exist(string path, bool createFolder)**:
    - Checks if a `path` exists. If `createFolder` is true, it will create the `path` if it doesn't exist.
- **NotExist(string path, bool createFolder)**:
    - Checks if a `path` does not exist. If `createFolder` is true, it will create the `path` if it doesn't exist.

### FileHelper:
- **GetFileExtention(string fileName)**:
    - Returns the extention of a `fileName`. If the `fileName` multiple extentions (Example: filename.txt.zip), it will return the last extention.
- **Exist(string fullFileName, bool createFile)**:
    - Checks if `fullFileName` exists. If `createFile` is true, it will create the `fullFileName` if it doesn't exist (Keep in mind that the path of the `fullFileName` must exist for `createFile` to work).
- **NotExist(string fullFileName, bool createFile)**:
    - Checks if `fullFileName` does not exist. If `createFile` is true, it will create the `fullFileName` if it doesn't exist (Keep in mind that the path of the `fullFileName` must exist for `createFile` to work).

### HtmlHelper:
- **EncodeHtml(string decodedHtml)**:
	- Converts a `decodedHtml` into a HTML-encoded string.
- **DecodeHtml(string encodedHtml)**:
	- Converts a `encodedHtml` into a decoded string.
- **GetHrefLink(string html)**:
	- Checks the `html` and tries to return the first link that is in between the **href=""**.
- **GetMultipleHrefLinks(string html)**:
	- Checks the `html` and tries to return multiple links that are in between the **href=""**.
- **GetTable(string html)**:
	- Checks the `html` and tries to return the first table that is in between the **\<table\>\<\table\>**.
- **GetMultipleTables(string html)**:
	- Checks the `html` and tries to return multiple tables that are in between the **\<table\>\<\table\>**.
- **GetRowsFromTable(string htmlTable)**:
	- Checks the `htmlTable` and tries to return the rows that are in between the **\<tr\>\<\tr\>**.
- **GetDataFromRows(string htmlTable)**:
	- Checks the `htmlTable` and tries to return the data that are in between the **\<td\>\<\td\>**.
- **GetMultipleDataFromTables(List\<string\> htmlTables)**:
	- Checks the `htmlTables` and tries to return all the data that are in multiple rows of multiple tables.

### ListHelper:
- **AddRange\<T\>(List\<T\> list, T[] array, int startIndex, int endIndex)**:
    - Adds the `array` into the `list`. If `statIndex` is specified, it will add the contents of the `array` only from `startIndex` (included) until the end of the array or until it reaches `endIndex` (included) if it is specified.
- **AddRange\<T\>(List\<T\> list, List\<T\> listToAdd, int index)**:
    - Adds the `listToAdd` into the `list`. If `index` is specified, it will add the contents of the `listToAdd` only from `index` (included) until the end of the list.
- **ToList\<T\>(T[] array)**:
    - Transforms an `array` into a List\<T\>.
- **OrderByAscending(List\<T\> list)**:
    - Orders a `list` in ascending order.
- **OrderByDescending\<T\>(List\<T\> list)**:
    - Orders a `list` in descending order. 
- **ToString\<T\>(List\<T\> list, string separator, int startIndex, int count)**
    - Converts an `list` into a single line of string. If `separator` is not passed, it will separate by a space. Examples: ListToString(new int[] { 1, 3, 5 }) -> "1 3 5", ListToString(new string[] { "5", "2" }, "|") -> "5|2".
- **HasAny\<T\>(List\<T\> list)**
    - Iterates through the `list`, checking that it has **at least 1** non null element.
- **GetValueLike(List\<string\> list, string value, StringComparison stringComparison)**
    - Iterates through the `list`, returning the first item found that contains `value`.
- **GetValueContaining(List\<string\> list, StringComparison stringComparison, string[] values)**
    - Iterates through the `list`, returning the first item found that contains all the `values`.
- **AddToElements(List\<string\> list, string startItemTag, string endItemTag)**
    - Iterates through the `list`, adding `startItemTag` before the item and `endItemTag` after the item. Example: `startItemTag` is 'www.' and the items inside the `list` are 'google.com'. This method will return the elements as 'www.google.com'.
- **RemoveFromElements(List\<string\> list, params string[] valuesToRemove)**
    - Returns a list where all occasions of `valuesToRemove` have been removed from the elements of the `list`.
- **ReplaceFromElements(List\<string\> list, string oldValue, string newValue)**
    - Returns a list where all occasions of `oldValue` have been replaced by `newValue` from the elements of the `list`.
- **GetBetween(List\<string\> stringList, string start, string end, bool startEndIncluded)**:
    - Iterates through the `stringList`, returning the first instance where both `start` and `end` are found. If none of the indexes match `start` and `end`, a `string.Empty` is returned. Use `startEndIncluded` if you want to include `start` and `end` in the returning string.
- **GetMultipleBetween(List\<string\> stringList, string start, string end, bool startEndIncluded)**:
    - Searches through the `stringList`, returning multiple instances found between `start` and `end`. Use `startEndIncluded` if you want to include `start` and `end` in the returning List<string>.
- **KeepBetween(List\<string\> stringList, string start, string end, bool startEndIncluded, bool excludeEmptyIndexes)**:
    - Iterates through the `stringList`, keeping the content between `start` and `end`. If `startEndIncluded` is enabled, the indexes will keep the `start` and `end`. If `excludeEmptyIndexes` is enabled, empty indexes will be removed from the list.
- **Exclude(List\<string\> stringList, string[] excludeStrings)**:
    - Iterates through the `stringList`, excluding the indexes that contain `excludeStrings`.
- **GetMultipleBetweenIndexes(List\<string\> stringList, string start, string end, bool startEndIncluded)**:
    - Searches through the `stringList`, returningmultiple instances found between `start` and `end` for each index. If you want only one instance per index, please use the method `GetMultipleBetween()`.
- **SplitListIntoSubLists\<T\>(List\<T\> currentList, int elementsPerSubList)**:
    - Splits a generic list into multiple sublists based on the number of elements you want to split, represented by `elementsPerSubList`.

### MultiHelper:
- **ClampValue\<T\>(T currentValue, T minValue, T maxValue)**:
    - Clamps `currentValue` based on its' parameters. Returns `maxValue` if `currentValue` is higher than it and returns `minValue` if it is lower than it.
- **AreNotNull\<T\>(params T[] objects)**:
	- Checks if all `objects` are **not** null. If all of `objects` are not null, returns `true`. Otherwise returns `false`.
- **IsBetween\<T\>(T value, T minValue, T maxValue, bool inclusive)**:
    - Checks if the `value` is in the range of `minValue` and `maxValue`. Setting `inclusive` to true will also include `minValue` and `maxValue` in the verification.
- **IsEquivalentTo(Type type, Type[] validTypes)**:
	- Determines whether `type` is equivalent to any `validTypes`.

### NumberHelper:
- **ToDecimal(string value)**:
    - Converts `value` into a decimal. If the conversion fails, returns a `0.0M`.
- **ToDouble(string value)**:
    - Converts `value` into a double. If the conversion fails, returns a `0.0d`.
- **ToInt(string value)**:
    - Converts `value` into a int. If the conversion fails, returns a `0`.
- **Max\<T\>(T[] sequence)**:
    - Returns the highest number present in the `sequence`.
- **Min\<T\>(T[] sequence)**:
    - Returns the lowest number present in the `sequence`.
- **IsNullOrZero\<T\>(T value)**:
    - Checks if `value` is a null or 0.

### StringHelper:
- **GetBetween(string text, string start, string end, bool startEndIncluded)**:
    - Searches through the `text`, returning the first instance found between `start` and `end`. Use `startEndIncluded` if you want to include `start` and `end` in the returning string.
- **GetMultipleBetween(string text, string startTag, string endTag, bool tagsIncluded)**:
    - Searches through the `text`, returning multiple instances found between `start` and `end`. Use `startEndIncluded` if you want to include `start` and `end` in the returning List of string.
- **GetBetweenReverse(string text, string start, string end, bool startEndIncluded)**:
    - Searches through the `text`, using the `start` as the **end tag** and then searches the `text` **backwards** until the `end` tag is found.
- **AndContains(string text, StringComparison stringComparison, string[] values)**:
    - Checks a `string` if it has all instances of `values`. If that's the case, then it returns `true`, otherwise it returns `false`.
- **OrContains(string text, StringComparison stringComparison, string[] values)**:
    - Checks a `string` if it has at least one instance of `values`. If that's the case, then it returns `true`, otherwise it returns `false`.
- **IsEmpty(string value)**:
    - Checks if the `value` is `null`, `string.Empty` or a white space ("", " ", "\n", "\r", ...)
- **IsNotEmpty(string value)**:
    - Check if the `value` contains any kind of character.
- **AreEmpty(string[] values)**:
    - Checks if all instances of `values` are null, string.Empty or a white space ("", " ", "\n", "\r", ...), returning `true` if **all** of them **are** empty.
- **AreNotEmpty(string[] values)**:
    - Checks if all instances of `values` contain any kind of character, returning `true` if **all** of them **are not** empty.
- **LetterUpperCase(string value, int index)**:
    - Changes a letter from `value` to be upper-case. If `index` is not passed, it will change the first letter of `value`.
- **LetterLowerCase(string value, int index)**:
    - Changes a letter from `value` to be lower-case. If `index` is not passed, it will change the first letter of `value`.
- **Remove(string value, params string[] valuesToRemove)**:
    - Returns a string where all instances of `valuesToRemove` have been removed from the `value`.
- **CharCount(string value, string valueToCount)**
    - Returns the count of `valueToCount` present in the `value`.
- **RemoveTags(string value, string[] tags)**
    - Returns a string where all instances of `tags` are removed from `value` (Example: Passing 'b' will remove all '\<b\>', '\</b\>' and \<b/\> xml tags).
- **Reverse(string value)**
    - Reverses a string.
- **Split(string value, string separator, bool keepSplitValue)**
    - Splits the `value` based on the `separator`. Use `keepSplitValue` to keep the `separator` on the values.
- **SeparateByUpperCase(string value, string separator)**
    -  Separates the `value` by upper-case characters.
- **SeparateByLowerCase(string value, string separator)**
    -  Separates the `value` by lower-case characters.
- **GetUpperCaseLetters(string value, string separator)**
    -  Reads the `value`, returning the present upper-case letters.
- **GetLowerCaseLetters(string value, string separator)**
    -  Reads the `value`, returning the present lower-case letters.
- **SplitBy(string value, SplitType splitType, bool keepSeparator, string separator)**
    -  Splits the `value` based on the `splitType`.

### TTable:
- **AddColumn(params string[] columnName)**:
- **AddColumn(params TTable[] columnName)**:
    - Adds a new `TTableColumn` in the `TTable`.
- **RenameColumn(string currentColumnName, string newColumnname)**:
	- Renames a column (if it exists).
- **GetColumn(params TTable[] columnName)**:
	- Returns an instance of `TTableColumn` if it is present in `TTable.ColumnList`. If it is not present, returns a null.  
- **GetColumns(int index)**:
	- Returns all `TTableColumn` present in `TTable.ColumnList`, or, if `index` is passed, returns the `TTableColumn` of the desired `index`.
- **MoveColumnIndex(TTableColumn tableColumn, int newIndex)**:
- **MoveColumnIndex(string columnName, int newIndex)**
    - Moves a `tableColumn`'s index to `newIndex`.
- **RemoveColumn(params TTableColumn[] tableColumn)**:
- **RemoveColumn(params string[] columnName)**
    - Removes a `tableColumn` from `TTable.ColumnList` (Method will use `TTableColumn.ColumnName` to determine which `TTableColumn` to remove from `TTable.ColumnList`.
- **AddData(string columnName, params object[] values)**:
- **AddData(TTableColumn tableColumn, params object[] values)**:
    - Adds `values` into the `TTableColumn` as `object`.
- **ExistsData(string columnName, object value)**:
- **ExistsData(TTableColumn tableColumn, object value)**:
    - Checks through the `TTableColumn` for `value`. Returns `true` if `value` is found, otherwise `false`.
- **GetData(string columnName)**:
    - If the `columnName` exists, returns all the data present in the `TTableColumn`.
- **RemoveData(string columnName, params object[] valuesToRemove)**:
- **RemoveData(TTableColumn tableColumn, params object[] valuesToRemove)**:
    - Removes all instances of `valuesToRemove`.
- **TableToCsv(bool addHeader, string separator)**:
    - Transform the `TTable` into a parseable `.csv` file.
- **CsvToTable(string fullFileName, string separator)**:
    - Transform a `.csv` file into a `TTable`.

### TTableColumn:
- **string ColumnName { get; set; }**:
    - Gets or sets the name of the column.  
- **List\<object\> ColumnData { get; set; }**:
    - Gets or sets the data in the column.
- **AddData(params object[] values)**:
    - Adds the values in the `ColumnData` as `object`.
- **ExistData(object value)**:
    - Checks through the `ColumnData` for `value`. Returns `true` if `value` is found, otherwise `false`.
- **RemoveData(params object[] values)**:
    - Removes all instances of `values`.
	
### XmlHelper:
- **RemoveEmptyTags(string xml)**:
	- Searches through the `xml`, removing empty tags that have the format of \<EmptyTag\\>.