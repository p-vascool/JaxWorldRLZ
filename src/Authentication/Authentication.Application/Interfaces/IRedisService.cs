using Authentication.Application.DTOs;
using JaxWorld.Common.Domain.Models.Users;

namespace Authentication.Application.Interfaces;

public interface IRedisService
{
    Task<bool> Create(CreateUserRequest request);

    Task<UserRedisDto> Get(string username, string password);

    Task<bool> Update(CreateUserRequest request);
}