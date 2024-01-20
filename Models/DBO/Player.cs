namespace Models.DBO;

public class Player : BaseDbo
{
    public string Name { get; set; } = Guid.NewGuid().ToString();
    public int WinCount { get; set; }
    public int LoseCount { get; set; }
    public PlayerStatusEnum Status { get; set; }
    public Session? LastSession { get; set; }
    public int? LastSessionId { get; set; }
}