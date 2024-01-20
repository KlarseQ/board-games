namespace Models.DTO;

using Extensions;
using System.Reflection;

public abstract class CardDto : BaseDto
{
    public GameTypeEnum Type { get; set; }
    public string TypeToString => Type.ToStringDescription();
    public string? TextValue { get; set; }
    public int? IntValue { get; set; }
    public string? ImagePath { get; set; }
}