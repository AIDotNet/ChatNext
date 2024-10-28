namespace ChatNext.Data.Model;

public class PagingResult<T>(IEnumerable<T> items, long totalCount)
{
    public IEnumerable<T> Items { get; } = items;

    public long TotalCount { get; } = totalCount;
}