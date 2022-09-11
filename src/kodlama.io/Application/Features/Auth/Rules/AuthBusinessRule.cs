using Application.Features.Auth.Constants;
using Application.Services.Repositories;
using Core.Security.Entities;
using Core.Security.Hashing;
using FluentValidation;

namespace Application.Features.Auth.Rules;

public class AuthBusinessRule
{
    IUserRepo _userRepo;

    public AuthBusinessRule(IUserRepo userRepo)
    {
        _userRepo = userRepo;
    }

    public async Task EmailCannotBeDuplicatedWhenRegistering(string email)
    {
        var user = await _userRepo.GetAsync(u => u.Email == email);
        if (user != null)
        {
            throw new ValidationException(Messages.EmailAlreadyExist);
        }
    }

    public void CheckUserExist(User? user)
    {
        if (user == null)
        {
            throw new ValidationException(Messages.UserNotFound);
        }
    }

    public void CheckPassword(User user, string password)
    {
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        {
            throw new ValidationException(Messages.PasswordIsWrong);
        }
    }
}