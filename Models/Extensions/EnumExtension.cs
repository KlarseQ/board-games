namespace Models.Extensions;

public static class EnumExtensions
{
    public static string ToStringDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());

        if (field == null)
            return value.ToString();
        var attribute = (DescriptionAttribute?)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));

        return attribute != null ? attribute.Description : value.ToString();
    }
}