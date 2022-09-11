using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public class GithubAccount : Entity
{
    public User User { get; set; }
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Url { get; set; }

    public GithubAccount()
    {
    }

    public GithubAccount(int id, int userId, string username, string url) : base(id)
    {
        Username = username;
        Url = url;
        UserId = userId;
    }
}