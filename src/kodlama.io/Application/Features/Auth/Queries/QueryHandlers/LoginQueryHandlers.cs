using Application.Features.Auth.Queries.Login;
using Application.Features.Auth.Rules;
using Application.Services.Repositories;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auth.Queries.QueryHandlers;

public class LoginQueryHandlers : IRequestHandler<LoginQuery, AccessToken>
{
    private readonly ITokenHelper _tokenHelper;
    private readonly AuthBusinessRule _authBusinessRule;
    private readonly IUserRepo _userRepo;

    public LoginQueryHandlers(ITokenHelper tokenHelper, AuthBusinessRule authBusinessRule, IUserRepo userRepo)
    {
        _tokenHelper = tokenHelper;
        _authBusinessRule = authBusinessRule;
        _userRepo = userRepo;
    }

    public async Task<AccessToken> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepo.GetAsync(u => u.Email == request.UserForLoginDto.Email);
        _authBusinessRule.CheckUserExist(user);
        _authBusinessRule.CheckPassword(user!, request.UserForLoginDto.Password);
        var operationClaims = user!.UserOperationClaims.Select(uoc => uoc.OperationClaim).ToList();
        var accessToken =
            _tokenHelper.CreateToken(user!, operationClaims);
        return accessToken;
    }
}