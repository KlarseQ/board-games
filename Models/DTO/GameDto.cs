namespace Models.DTO;

using Extensions;

public abstract class GameDto : BaseDto
{
    public GameTypeEnum Type { get; set; }
    public string TypeToString => Type.ToStringDescription();
    public string? Description { get; set; }
}