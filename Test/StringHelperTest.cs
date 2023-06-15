using TsadriuUtilities;
using TsadriuUtilities.Enums;

namespace Test
{
    [TestFixture]
    public class StringHelperTest
    {
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

            bool caseSix = text.GetBetween(string.Empty, "How are you?") == string.Empty;
            bool caseSeven = text.GetBetween("Good morning", "How are you?") == string.Empty;
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
                text.GetBetween(string.Empty, string.Empty, comparison, startEndIncluded);
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
        public void GetManyBetween_Returns_Substrings_Between_Start_And_End_On_Xml_File()
        {
            string xmlFile = File.ReadAllText("C:\\Users\\foliveira\\Documents\\GitHub\\TsadriuUtilities\\Test\\Files\\StringHelper\\06724610966_09328470159_202305_TGL_20230606000200_01_M.XML");
            IEnumerable<string> listOfRaccolte = xmlFile.GetManyBetween("<Raccolta>", "</Raccolta>", StringComparison.OrdinalIgnoreCase).ToList();

            Assert.That(listOfRaccolte, Is.Not.Null);
            Assert.That(listOfRaccolte.Count, Is.EqualTo(723));
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
    }
}
