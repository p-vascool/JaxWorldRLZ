namespace JaxWorld.Common.Domain.Models.Users;

public sealed record UserDetailsRedisDto(
    string Id,
    string FirstName,
    string LastName,
    int Age);