namespace Models.DBO;

public class CardDeck : BaseDbo, IRemovable
{
    public ICollection<Card> Cards { get; set; } = new List<Card>();
    public Game? Game { get; set; }
    public int? GameId { get; set; }
    public Session? Session { get; set; }
    public int? SessionId { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
}