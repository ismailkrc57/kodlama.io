using Application.Features.Users.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;

namespace Application.Features.Users.Rules;

public class UserBusinessRule
{
    private readonly IUserRepo _userRepo;

    public UserBusinessRule(IUserRepo userRepo)
    {
        _userRepo = userRepo;
    }

    public async Task EmailMustBeUniqueWhenUpdatedUser(string email, int id)
    {
        var user = await _userRepo.GetAsync(u => u.Email == email && u.Id != id);
        if (user != null)
        {
            throw new BusinessException(Messages.EmailAlreadyExist);
        }
    }

    public void UserMustBeExist(User? user)
    {
        if (user == null)
        {
            throw new BusinessException(Messages.UserNotFound);
        }
    }
}