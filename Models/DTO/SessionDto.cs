namespace Models.DTO;

public abstract class SessionDto : BaseDto
{
    public List<PlayerDto> Players { get; set; } = new();
    public GameDto? Game { get; set; }
    public int? GameId { get; set; }
    public CardDeckDto? CardDeck { get; set; }
    public int? CardDeckId { get; set; }
    public List<PlayerMoveDto> PlayerMoves { get; set; } = new();
}