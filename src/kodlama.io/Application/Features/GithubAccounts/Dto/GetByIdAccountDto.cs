namespace Application.Features.GithubAccounts.Dto;

public class GetByIdAccountDto : AccountDto
{
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
}