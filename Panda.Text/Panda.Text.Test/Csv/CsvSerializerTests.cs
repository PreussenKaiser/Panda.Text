using Panda.Text.Convert;
using Panda.Text.Test.Utilities;

namespace Panda.Text.Test.Csv;

public sealed class CsvSerializerTests
{
	[Fact]
	public void Deserialize_HappyPath()
	{
		// Arrange
		string[] csv = [
			"FirstName,LastName,Age",
			"Karl,Lukan,21",
			"Blingus,Zabloing,2147483648",
			"Plimper Jingleson,,-2"];
		IEnumerable<Person> expected = [
			new Person { FirstName = "Karl", LastName = "Lukan", Age = "21" },
			new Person { FirstName = "Blingus", LastName = "Zabloing", Age = "2147483648" },
			new Person { FirstName = "Plimper Jingleson", LastName = string.Empty, Age = "-2" },];

		// Act
		IEnumerable<Person> actual = CsvSerializer.Deserialize<Person>(csv);

		// Assert
		Assert.Equal(expected, actual);
	}
}
