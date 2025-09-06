namespace Authentication.Application.DTOs;

public sealed record CreateUserRequest(
    string Username,
    string Password,
    string FirstName,
    string LastName,
    string Email,
    int Age);