namespace Models.DBO;

public class Session : BaseDbo, IRemovable
{
    public ICollection<Player> Players { get; set; } = new List<Player>();
    public Game? Game { get; set; }
    public int? GameId { get; set; }
    public CardDeck? CardDeck { get; set; }
    public int? CardDeckId { get; set; }
    public ICollection<PlayerMove> PlayerMoves { get; set; } = new List<PlayerMove>();
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
}