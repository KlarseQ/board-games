namespace Models.DBO;

public class PlayerMove : BaseDbo, IRemovable
{
    public Player? Player { get; set; }
    public int? PlayerId { get; set; }
    public Session? Session { get; set; }
    public int? SessionId { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
}