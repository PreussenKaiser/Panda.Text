namespace Panda.Csv.Abstractions;

public interface ICsvService
{
    Task<IEnumerable<T>> ReadAsync<T>(CancellationToken cancellationToken = default) where T : new();
}
