namespace Deepin.Chatting.Application.Models;

public class ChatInfo
{
    public required string Name { get; set; }
    public string? UserName { get; set; }
    public string? Description { get; set; }
    public string? AvatarFileId { get; set; }
    public bool IsPublic { get; set; }
}
