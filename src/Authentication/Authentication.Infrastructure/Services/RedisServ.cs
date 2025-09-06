using Authentication.Application.DTOs;
using Authentication.Application.Interfaces;
using Authentication.Infrastructure.Persistance.Repositories;
using JaxWorld.Common.Domain.Models.Users;

namespace Authentication.Infrastructure.Services;

public class RedisService(RedisRepository<UserRedisDto> redisRepository) : IRedisService
{
    private readonly RedisRepository<UserRedisDto> _redisRepository = redisRepository;

    public Task<bool> Create(CreateUserRequest request)
    {
        // _redisRepository.Create(request);
        return Task.FromResult(true);
    }

    public Task<UserRedisDto> Get(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(CreateUserRequest request)
    {
        throw new NotImplementedException();
    }
}