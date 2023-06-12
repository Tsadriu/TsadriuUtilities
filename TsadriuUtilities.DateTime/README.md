# TsadriuUtilities.DateTime
### _A small package that helps on manipulating and managing DateTime types._

TsadriuUtilities.DateTime is a small library that helps on manipulating and managing DateTime types.
## > Features <

### DateTimeHelper:
- **ToDateTime(string date, CultureInfo cultureInfo, DateTimeStyles? dateTimeStyle, params string[] formats)** + 2 overload:
    - Attempts to convert a date from a `string` to a `DateTime` object.
- **ToNullableDateTime(string date, CultureInfo cultureInfo, DateTimeStyles? dateTimeStyle, params string[] formats)** + 2 overload:
    - Attempts to convert a date from a `string` to a nullable `DateTime`.
- **GetLastDayOfMonth(DateTime date)**:
    - Parses the `date` to return with the last day of the month.
- **SetDay(DateTime date, int day)**:
    - Sets the `day` of the month in the specified `date`.
- **SetMonth(DateTime date, int month)**:
    - Sets the `month` of the month in the specified `date`.
- **SetYear(DateTime date, int year)**:
    - Sets the `year` of the month in the specified `date`.
- **RemoveDays(DateTime date, int days)**:
    - Removes the specified number of days from the given `days` and returns the resulting `date`.
- **RemoveMonths(DateTime date, int months)**:
    - Removes the specified number of months from the given `months` and returns the resulting `date`.
- **RemoveYears(DateTime date, int years)**:
    - Removes the specified number of years from the given `years` and returns the resulting `date`.
