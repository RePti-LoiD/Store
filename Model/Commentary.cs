namespace Store.Model;

public class Commentary
{
    private string userId;
    private string content;
    private long time;
    private int likes;

    public string UserId { get => userId; set => userId = value; }
    public string Content { get => content; set => content = value; }
    public long Time { get => time; set => time = value; }
    public int Likes { get => likes; set => likes = value; }
}