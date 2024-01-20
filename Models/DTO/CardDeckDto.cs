namespace Models.DTO;

public abstract class CardDeckDto : BaseDto
{
    public List<CardDto> Cards { get; set; } = new();
    public GameDto? Game { get; set; }
    public int? GameId { get; set; }
    public SessionDto? Session { get; set; }
    public int? SessionId { get; set; }
}