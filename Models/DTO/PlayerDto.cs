namespace Models.DTO;

using Extensions;

public abstract class PlayerDto : BaseDto
{
    public string Name { get; set; } = Guid.NewGuid().ToString();
    public PlayerStatusEnum Status { get; set; }
    public string StatusToString => Status.ToStringDescription();
    public SessionDto? LastSession { get; set; }
    public int? LastSessionId { get; set; }
}