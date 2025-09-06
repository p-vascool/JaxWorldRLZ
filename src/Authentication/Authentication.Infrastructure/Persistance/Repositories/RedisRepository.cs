using System.Linq.Expressions;
using Authentication.Application.Persistance;
using MessagePack;
using StackExchange.Redis;
using static System.String;

namespace Authentication.Infrastructure.Persistance.Repositories;

public sealed class RedisRepository<TItem>(IDatabase redisDb)
    : IRepository<TItem, string>
    where TItem : class
{
    private readonly IDatabase _redisDb = redisDb;

    private static string Key(string id)
        => Format("{prefix}:{id}", typeof(TItem).Name.ToLower(), id);

    public async Task<TItem> Get(string id)
    {
        var value = await _redisDb.StringGetAsync(Key(id));
        return value.HasValue ? Deserialize(value!) : null;
    }

    public Task<IEnumerable<TItem>> GetAll()
        => throw new NotSupportedException("Use indexed queries instead of full scans in Redis.");


    public async Task Create(TItem item)
    {
        var idProp = typeof(TItem).GetProperty("Id") ?? throw new InvalidOperationException("TItem must have Id");
        var id = idProp.GetValue(item)?.ToString();
        await _redisDb.StringSetAsync(Key(id), Serialize(item));
    }


    public Task Update(TItem item)
    {
        throw new NotImplementedException();
    }

    public Task Delete(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TItem>> GetBy(Expression<Func<TItem, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    private static byte[] Serialize(TItem item)
        => MessagePackSerializer.Serialize(item);

    private static TItem Deserialize(byte[] bytes)
        => MessagePackSerializer.Deserialize<TItem>(bytes);
}