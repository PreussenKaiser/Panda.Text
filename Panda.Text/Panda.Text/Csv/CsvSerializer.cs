using System.Reflection;

namespace Panda.Text.Convert;

public static class CsvSerializer
{
	public static IEnumerable<T> Deserialize<T>(string[] csv)
	{
		string[] headers = csv[0].Split(',');
		string[] body = csv[1..];

		var result = new T[body.Length];
		for (var i = 0; i < body.Length; i++)
		{
			string[] values = body[i].Split(",");
			var entity = Activator.CreateInstance<T>();

			for (var j = 0; j < values.Length; j++)
			{
				typeof(T)
					.GetProperty(headers[j])
					?.SetValue(entity, values[j]);
			}

			result[i] = entity;
		}

		return result;
	}
}
