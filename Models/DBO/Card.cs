namespace Models.DBO;

public class Card : BaseDbo, IRemovable
{
    public GameTypeEnum Type { get; set; }
    public string? TextValue { get; set; }
    public int? IntValue { get; set; }
    public string? ImagePath { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
}