
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public static class ColorHelper
{
    

    private static readonly Dictionary<Color, string> ColorNames =
    typeof(Color)
        .GetProperties(BindingFlags.Public | BindingFlags.Static)
        .Where(p => p.PropertyType == typeof(Color))
        .GroupBy(p => (Color)p.GetValue(null)!)
        .ToDictionary(
            g => g.Key,
            g => g.First().Name);

    public static string ToColorName(this Color color)
    {
        return ColorNames.TryGetValue(color, out string? name)
            ? name
            : $"RGB({color.R}, {color.G}, {color.B})";
    }
}
