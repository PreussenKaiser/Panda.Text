namespace Panda.Csv.Abstractions;

public interface IFileService
{
    Task<string[]> ReadAllLinesAsync(string path, CancellationToken cancellationToken = default);
}
