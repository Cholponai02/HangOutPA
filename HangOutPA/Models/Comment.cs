namespace HangOutPA.Models;

public class Comment
{
    public string UserName { get; set; }
    public string Text { get; set; }
    public string UserAvatar { get; set; }
    public DateTime CreatedAt { get; set; }
}