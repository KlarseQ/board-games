namespace Models.DTO;

public abstract class PlayerMoveDto : BaseDto
{
    public PlayerDto? Player { get; set; }
    public int? PlayerId { get; set; }
    public SessionDto? Session { get; set; }
    public int? SessionId { get; set; }
    public DateTime CreatedOn { get; set; }
}