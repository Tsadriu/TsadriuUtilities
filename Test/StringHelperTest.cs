using NUnit.Framework.Internal;
using TsadriuUtilities;
using TsadriuUtilities.Enums;

namespace Test
{
    [TestFixture]
    public class StringHelperTest
    {
        [Test]
        public void GetBetween_StartNotFoundButEndWasFound_ReturnsStringEmpty()
        {
            // Arrange
            string text = "Quota assicurazione gas delibera Aeeg 191/2013/R/GAS e s.m.i. 1O 221,85";
            string start = "1K";
            string end = " ";
            StringComparison comparison = StringComparison.Ordinal;
            bool startEndIncluded = false;

            // Act
            string result = text.GetBetween(start, end, comparison, startEndIncluded);

            // Assert
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void GetBetween_StartHasValueAndEndIsWhiteSpace_ReturnsSubstring()
        {
            // Arrange
            string text = "N. 21DVI04646 DEL 10/06/2021\nPeriodo di riferimento: 01/05/2021 - 31/05/2021\nQuantitï¿½ Vettoriata (smc): 3.490,228166\nDettaglio Voci Fattura Rif. IVA Importo";
            string start = "Quantit";
            string end = "\n";
            StringComparison comparison = StringComparison.Ordinal;
            bool startEndIncluded = false;

            // Act
            string result = text.GetBetween(start, end, comparison, startEndIncluded);

            // Assert
            Assert.That(result, Is.EqualTo("ï¿½ Vettoriata (smc): 3.490,228166"));
        }

        [Test]
        public void GetBetween_BothStartAndEndFound_ReturnsSubstring()
        {
            // Arrange
            string text = "Hello [world].";
            string start = "[";
            string end = "]";
            StringComparison comparison = StringComparison.Ordinal;
            bool startEndIncluded = false;

            // Act
            string result = text.GetBetween(start, end, comparison, startEndIncluded);

            // Assert
            Assert.That(result, Is.EqualTo("world"));
        }

        [Test]
        public void GetBetween_StartFoundAndEndIsEmpty_ReturnsSubstringFromStartParamUntilEndOfText()
        {
            // Arrange
            string text = "Hello this is a beautiful day.";
            string start = "this";
            string end = string.Empty;
            StringComparison comparison = StringComparison.Ordinal;
            bool startEndIncluded = false;

            // Act
            string result = text.GetBetween(start, end, comparison, startEndIncluded);

            // Assert
            Assert.That(result, Is.EqualTo(" is a beautiful day."));
        }

        [Test]
        public void GetBetween_StartIsEmptyAndEndIsFound_ReturnsSubstringFromStartOfTextUntilEndParam()
        {
            // Arrange
            string text = "Hello this is a beautiful day.";
            string start = string.Empty;
            string end = "day";
            StringComparison comparison = StringComparison.Ordinal;
            bool startEndIncluded = false;

            // Act
            string result = text.GetBetween(start, end, comparison, startEndIncluded);

            // Assert
            Assert.That(result, Is.EqualTo("Hello this is a beautiful "));
        }

        [Test]
        public void GetBetween_StartAndEndAreEmpty_ThrowsArgumentNullException()
        {
            // Arrange
            string text = "Hello this is a beautiful day.";
            string start = string.Empty;
            string end = string.Empty;
            StringComparison comparison = StringComparison.Ordinal;
            bool startEndIncluded = false;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                text.GetBetween(start, end, comparison, startEndIncluded);
            });
        }

        [Test]
        public void GetBetween_StartIsNotFoundAndEndIsEmpty_ReturnsEmptyString()
        {
            // Arrange
            string text = "Hello this is a beautiful day.";
            string start = "Good morning";
            string end = string.Empty;
            StringComparison comparison = StringComparison.Ordinal;
            bool startEndIncluded = false;

            // Act
            string result = text.GetBetween(start, end, comparison, startEndIncluded);

            // Assert
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void GetBetween_StartIsEmptyAndEndIsNotFound_ReturnsEmptyString()
        {
            // Arrange
            string text = "Hello this is a beautiful day.";
            string start = string.Empty;
            string end = "How are you?";
            StringComparison comparison = StringComparison.Ordinal;
            bool startEndIncluded = false;

            // Act
            string result = text.GetBetween(start, end, comparison, startEndIncluded);

            // Assert
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void GetBetween_StartAndEndAreNotFound_ReturnsEmptyString()
        {
            // Arrange
            string text = "Hello this is a beautiful day.";
            string start = "Good morning";
            string end = "How are you?";
            StringComparison comparison = StringComparison.Ordinal;
            bool startEndIncluded = false;

            // Act
            string result = text.GetBetween(start, end, comparison, startEndIncluded);

            // Assert
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void GetBetween_StartNotFoundAndEndNull_ReturnsEmptyString()
        {
            // Arrange
            string text = "Hello world.";
            string start = "foo";
            string? end = null;
            StringComparison comparison = StringComparison.Ordinal;
            bool startEndIncluded = false;

            // Act
            string result = text.GetBetween(start, end, comparison, startEndIncluded);

            // Assert
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void GetBetween_EndNotFoundAndStartEmpty_ReturnsEmptyString()
        {
            // Arrange
            string text = "Hello world.";
            string start = "";
            string end = "bar";
            StringComparison comparison = StringComparison.Ordinal;
            bool startEndIncluded = false;

            // Act
            string result = text.GetBetween(start, end, comparison, startEndIncluded);

            // Assert
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void GetBetween_BothStartAndEndNotFound_ReturnsEmptyString()
        {
            // Arrange
            string text = "Hello world.";
            string start = "foo";
            string end = "bar";
            StringComparison comparison = StringComparison.Ordinal;
            bool startEndIncluded = false;

            // Act
            string result = text.GetBetween(start, end, comparison, startEndIncluded);

            // Assert
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void GetBetween_StartEndIncluded_ReturnsSubstringWithTags()
        {
            // Arrange
            string text = "Hello [world].";
            string start = "[";
            string end = "]";
            StringComparison comparison = StringComparison.Ordinal;
            bool startEndIncluded = true;

            // Act
            string result = text.GetBetween(start, end, comparison, startEndIncluded);

            // Assert
            Assert.That(result, Is.EqualTo("[world]"));
        }

        [Test]
        public void GetBetweenReverse_ReturnsSubstringBetweenStartAndEnd()
        {
            // Arrange
            string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";
            string start = "adipiscing";
            string end = "ipsum";
            bool startEndIncluded = false;

            // Act
            string result = text.GetBetweenReverse(start, end, startEndIncluded);

            // Assert
            string expected = " dolor sit amet, consectetur ";
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetBetweenReverse_ReturnsEmptyString_WhenTextIsEmpty()
        {
            // Arrange
            string text = "";
            string start = "ipsum";
            string end = "adipiscing";
            bool startEndIncluded = false;

            // Act
            string result = text.GetBetweenReverse(start, end, startEndIncluded);

            // Assert
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void GetBetweenReverse_ReturnsEmptyString_WhenStartAndEndNotFound()
        {
            // Arrange
            string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";
            string start = "nonexistent";
            string end = "tags";
            bool startEndIncluded = false;

            // Act
            string result = text.GetBetweenReverse(start, end, startEndIncluded);

            // Assert
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void GetBetweenReverse_ReturnsSubstringWithStartAndEnd_WhenStartEndIncludedIsTrue()
        {
            // Arrange
            string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";
            string start = "adipiscing";
            string end = "ipsum";
            bool startEndIncluded = true;

            // Act
            string result = text.GetBetweenReverse(start, end, startEndIncluded);

            // Assert
            string expected = "ipsum dolor sit amet, consectetur adipiscing";
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetManyBetween_Returns_Substrings_Between_Start_And_End()
        {
            // Arrange
            string text = "Hello [World]! [How] are [you] doing?";
            string start = "[";
            string end = "]";
            StringComparison comparison = StringComparison.Ordinal;
            bool startEndIncluded = false;

            // Act
            IEnumerable<string> result = text.GetManyBetween(start, end, comparison, startEndIncluded).ToList();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(new[] { "World", "How", "you" }));
        }

        [Test]
        public void GetManyBetween_ReturnsSubstringsWithTags_BetweenStartAndEnd_OnXmlFile()
        {
            // Arrange
            string xmlFile = File.ReadAllText("C:\\Users\\foliveira\\Documents\\GitHub\\TsadriuUtilities\\Test\\Files\\StringHelper\\06724610966_09328470159_202305_TGL_20230606000200_01_M.XML");

            // Act
            List<string> result = xmlFile.GetManyBetween("<Raccolta>", "</Raccolta>", true).ToList();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Count.EqualTo(723));
            Assert.Multiple(() =>
            {
                foreach (string item in result)
                {
                    Assert.That(item, Does.Contain("<Raccolta>"));
                    Assert.That(item, Does.Contain("</Raccolta>"));
                }
            });
        }

        [Test]
        public void GetManyBetween_Throws_Argument_Null_Exception_When_Start_Is_Null()
        {
            // Arrange
            string text = "Hello [World]!";
            string? start = null;
            string end = "]";
            StringComparison comparison = StringComparison.Ordinal;
            bool startEndIncluded = false;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                text.GetManyBetween(start, end, comparison, startEndIncluded);
            });
        }

        [Test]
        public void GetManyBetween_Throws_Argument_Null_Exception_When_End_Is_Null()
        {
            // Arrange
            string text = "Hello [World]!";
            string start = "[";
            string? end = null;
            StringComparison comparison = StringComparison.Ordinal;
            bool startEndIncluded = false;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                text.GetManyBetween(start, end, comparison, startEndIncluded);
            });
        }

        [Test]
        public void GetManyBetween_Returns_Empty_List_When_Text_Does_Not_Contain_Start_Or_End()
        {
            // Arrange
            string text = "Hello World!";
            string start = "[";
            string end = "]";
            StringComparison comparison = StringComparison.Ordinal;
            bool startEndIncluded = false;

            // Act
            IEnumerable<string> result = text.GetManyBetween(start, end, comparison, startEndIncluded).ToList();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void GetManyBetween_Returns_Empty_List_When_Text_Is_Null()
        {
            // Arrange
            string? text = null;
            string start = "[";
            string end = "]";
            StringComparison comparison = StringComparison.Ordinal;
            bool startEndIncluded = false;

            // Act
            IEnumerable<string> result = text.GetManyBetween(start, end, comparison, startEndIncluded).ToList();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void IsEmpty_When_String_Is_Null_Returns_True()
        {
            // Arrange
            string? value = null;

            // Act
            bool result = value.IsEmpty();

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsEmpty_When_String_Is_Empty_Returns_True()
        {
            // Arrange
            string value = "";

            // Act
            bool result = value.IsEmpty();

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsEmpty_When_String_Contains_Only_Whitespace_Returns_True()
        {
            // Arrange
            string value = "   ";

            // Act
            bool result = value.IsEmpty();

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsEmpty_When_String_Contains_Non_Whitespace_Characters_Returns_False()
        {
            // Arrange
            string value = "Hello";

            // Act
            bool result = value.IsEmpty();

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsNotEmpty_When_String_Is_Null_Returns_False()
        {
            // Arrange
            string? value = null;

            // Act
            bool result = value.IsNotEmpty();

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsNotEmpty_When_String_Is_Empty_Returns_False()
        {
            // Arrange
            string value = "";

            // Act
            bool result = value.IsNotEmpty();

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsNotEmpty_When_String_Contains_Only_Whitespace_Returns_False()
        {
            // Arrange
            string value = "   ";

            // Act
            bool result = value.IsNotEmpty();

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsNotEmpty_When_String_Contains_Non_Whitespace_Characters_Returns_True()
        {
            // Arrange
            string value = "Hello";

            // Act
            bool result = value.IsNotEmpty();

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void ReplaceManyWith_Replaces_Values_In_String()
        {
            // Arrange
            string value = "Hello, world!";
            string?[] valuesToRemove = { "Hello", "!" };
            string expected = ", world";

            // Act
            string result = value.RemoveMany(valuesToRemove);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ReplaceManyWith_When_No_Values_To_Remove_Returns_Original_String()
        {
            // Arrange
            string value = "Hello, world!";
            string?[]? valuesToRemove = null;
            string expected = "Hello, world!";

            // Act
            string result = value.RemoveMany(valuesToRemove);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ReplaceManyWith_When_Values_To_Remove_Contains_Null_Removes_Only_Valid_Values()
        {
            // Arrange
            string value = "Hello, world!";
            string?[] valuesToRemove = { "Hello", null, "!" };
            string expected = ", world";

            // Act
            string result = value.RemoveMany(valuesToRemove);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ReplaceManyWith_When_Values_To_Remove_Contains_Empty_Strings_Returns_String_With_Empty_String_Removed()
        {
            // Arrange
            string value = "Hello, , world!";
            string?[] valuesToRemove = { "", " " };
            string expected = "Hello,,world!";

            // Act
            string result = value.RemoveMany(valuesToRemove);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TextCount_Returns_Correct_Count()
        {
            // Arrange
            string value = "Hello, hello, hello!";
            string valueToCount = "hello";
            int expectedCount = 2;

            // Act
            int result = value.TextCount(valueToCount);

            // Assert
            Assert.That(result, Is.EqualTo(expectedCount));
        }

        [Test]
        public void TextCount_When_Value_To_Count_Is_Empty_Returns_Zero()
        {
            // Arrange
            string value = "Hello, hello, hello!";
            string valueToCount = "";
            int expectedCount = 0;

            // Act
            int result = value.TextCount(valueToCount);

            // Assert
            Assert.That(result, Is.EqualTo(expectedCount));
        }

        [Test]
        public void TextCount_When_Value_To_Count_Does_Not_Exist_Returns_Zero()
        {
            // Arrange
            string value = "Hello, hello, hello!";
            string valueToCount = "world";
            int expectedCount = 0;

            // Act
            int result = value.TextCount(valueToCount);

            // Assert
            Assert.That(result, Is.EqualTo(expectedCount));
        }

        [Test]
        public void SplitBy_Returns_Correct_List()
        {
            // Arrange
            string value = "Hello-World-Test";
            StringSplitByEnum splitByEnum = StringSplitByEnum.Dash;
            bool keepSeparator = false;
            List<string> expectedList = new List<string> { "Hello", "World", "Test" };

            // Act
            List<string> resultList = value.SplitBy(splitByEnum, keepSeparator);

            // Assert
            Assert.That(resultList, Is.EqualTo(expectedList));
        }

        [Test]
        public void SplitBy_When_Keep_Separator_Is_True_Returns_List_With_Separators()
        {
            // Arrange
            string value = "Hello-World-Test";
            StringSplitByEnum splitByEnum = StringSplitByEnum.Dash;
            bool keepSeparator = true;
            List<string> expectedList = new List<string> { "Hello", "-World", "-Test" };

            // Act
            List<string> resultList = value.SplitBy(splitByEnum, keepSeparator);

            // Assert
            Assert.That(resultList, Is.EqualTo(expectedList));
        }

        [Test]
        public void SplitBy_When_Split_By_Enum_Is_User_Defined_Returns_List_With_Custom_Separator()
        {
            // Arrange
            string value = "Hello,World,Test";
            StringSplitByEnum splitByEnum = StringSplitByEnum.UserDefined;
            bool keepSeparator = false;
            string separator = ",";
            List<string> expectedList = new List<string> { "Hello", "World", "Test" };

            // Act
            List<string> resultList = value.SplitBy(splitByEnum, keepSeparator, separator);

            // Assert
            Assert.That(resultList, Is.EqualTo(expectedList));
        }

        [Test]
        public void SplitBy_When_Split_By_Enum_Not_Implemented_Throws_Not_Implemented_Exception()
        {
            // Arrange
            string value = "Hello,World,Test";
            StringSplitByEnum splitByEnum = (StringSplitByEnum)99; // An invalid enum value
            bool keepSeparator = false;

            // Act & Assert
            Assert.Throws<NotImplementedException>(() => value.SplitBy(splitByEnum, keepSeparator));
        }

        [Test]
        public void ContainsAll_ShouldReturnTrue_WhenAllValuesExistInText()
        {
            // Arrange
            string text = "This is a sample text";
            StringComparison comparison = StringComparison.OrdinalIgnoreCase;
            string[] values = { "sample", "text" };

            // Act
            bool result = text.ContainsAll(comparison, values);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void ContainsAll_ShouldReturnFalse_WhenAtLeastOneValueIsMissingInText()
        {
            // Arrange
            string text = "This is a sample text";
            StringComparison comparison = StringComparison.OrdinalIgnoreCase;
            string[] values = { "sample", "missing" };

            // Act
            bool result = text.ContainsAll(comparison, values);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void ContainsAny_ShouldReturnTrue_WhenAnyValueExistsInText()
        {
            // Arrange
            string text = "This is a sample text";
            StringComparison comparison = StringComparison.OrdinalIgnoreCase;
            string[] values = { "sample", "missing" };

            // Act
            bool result = text.ContainsAny(comparison, values);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void ContainsAny_ShouldReturnFalse_WhenNoValueExistsInText()
        {
            // Arrange
            string text = "This is a sample text";
            StringComparison comparison = StringComparison.OrdinalIgnoreCase;
            string[] values = { "nonexistent", "missing" };

            // Act
            bool result = text.ContainsAny(comparison, values);

            // Assert
            Assert.That(result, Is.False);
        }
        
        [Test]
        [TestCase("", ExpectedResult = "")]
        [TestCase("Hello World", ExpectedResult = "HW")]
        [TestCase("IdUm", ExpectedResult = "IU")]
        [TestCase("12345", ExpectedResult = "")]
        [TestCase("UPPERCASE", ExpectedResult = "UPPERCASE")]
        public string GetUppercaseLettersTest(string input)
        {
            return input.GetUppercaseLetters();
        }

        [Test]
        [TestCase("", ExpectedResult = "")]
        [TestCase("Hello World", ExpectedResult = "elloorld")]
        [TestCase("IdUm", ExpectedResult = "dm")]
        [TestCase("12345", ExpectedResult = "")]
        [TestCase("lowercase", ExpectedResult = "lowercase")]
        public string GetLowercaseLettersTest(string input)
        {
            return input.GetLowercaseLetters();
        }

        [Test]
        [TestCase("", -1, -1, ExpectedResult = "")]
        [TestCase(null, -1, -1, ExpectedResult = null)]
        [TestCase("Hello World", -1, -1, ExpectedResult = "hello world")]
        [TestCase("Hello World", 0, 4, ExpectedResult = "hello World")]
        [TestCase("Hello World", 6, 10, ExpectedResult = "Hello world")]
        [TestCase("Hello World", 6, 100, ExpectedResult = "Hello World")]
        public string ToLower_StartEndIndex(string input, int startIndex, int endIndex)
        {
            return input.ToLower(startIndex, endIndex);
        }

        [Test]
        [TestCase("Hello World", -1, 3)]
        public void ToLower_StartEndIndex_Throws(string input, int startIndex, int endIndex)
        {
            // Act & Assert
            Assert.Throws<Exception>(() => input.ToLower(startIndex, endIndex));
        }

        [Test]
        [TestCase("", -1, -1, ExpectedResult = "")]
        [TestCase(null, -1, -1, ExpectedResult = null)]
        [TestCase("Hello World", -1, -1, ExpectedResult = "HELLO WORLD")]
        [TestCase("Hello World", 0, 4, ExpectedResult = "HELLO World")]
        [TestCase("Hello World", 6, 10, ExpectedResult = "Hello WORLD")]
        [TestCase("Hello World", 6, 100, ExpectedResult = "Hello World")]
        public string ToUpper_StartEndIndex(string input, int startIndex, int endIndex)
        {
            return input.ToUpper(startIndex, endIndex);
        }

        [Test]
        [TestCase("Hello World", 2, -1)]
        public void ToUpper_StartEndIndex_Throws(string input, int startIndex, int endIndex)
        {
            // Act & Assert
            Assert.Throws<Exception>(() => input.ToUpper(startIndex, endIndex));
        }

        [Test]
        [TestCase("", -1, ExpectedResult = "")]
        [TestCase(null, -1, ExpectedResult = null)]
        [TestCase("Hello World", -1, ExpectedResult = "hello world")]
        [TestCase("Hello World", 0, ExpectedResult = "hello World")]
        [TestCase("Hello World", 6, ExpectedResult = "Hello world")]
        [TestCase("Hello World", 100, ExpectedResult = "Hello World")]
        public string ToLower_Index(string input, int index)
        {
            return input.ToLower(index);
        }

        [Test]
        [TestCase("", -1, ExpectedResult = "")]
        [TestCase(null, -1, ExpectedResult = null)]
        [TestCase("Hello World", -1, ExpectedResult = "HELLO WORLD")]
        [TestCase("hello world", 0, ExpectedResult = "Hello world")]
        [TestCase("hello world", 6, ExpectedResult = "hello World")]
        [TestCase("Hello World", 100, ExpectedResult = "Hello World")]
        public string ToUpper_Index(string input, int index)
        {
            return input.ToUpper(index);
        }
    }
}
