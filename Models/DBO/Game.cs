namespace Models.DBO;

public class Game : BaseDbo
{
    public int InitCount { get; set; }
    public GameTypeEnum Type { get; set; }
    public string? Description { get; set; }
}