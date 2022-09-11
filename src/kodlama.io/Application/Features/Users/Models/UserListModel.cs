using Application.Features.Users.Dto;
using Core.Persistence.Paging;

namespace Application.Features.Users.Models;

public class UserListModel : BasePageableModel

{
    public List<UserListDto> Items { get; set; }
}