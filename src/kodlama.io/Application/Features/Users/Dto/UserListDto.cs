namespace Application.Features.Users.Dto;

public class UserListDto : UserDto
{
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public bool Status { get; set; }
}