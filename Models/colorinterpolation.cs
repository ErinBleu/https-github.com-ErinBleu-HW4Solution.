using System.Collections.Generic;
using System.Drawing;

public class ColorInterpolation
{
    public string StartColor { get; set; } = "#000000";
    public string EndColor { get; set; } = "#FFFFFF";
    public int Steps { get; set; } = 5;
    public List<string> Colors { get; set; } = new();

    public void GenerateColors()
    {
        Color start = ColorTranslator.FromHtml(StartColor);
        Color end = ColorTranslator.FromHtml(EndColor);

        ColorToHSV(start, out double h1, out double s1, out double v1);
        ColorToHSV(end, out double h2, out double s2, out double v2);

        for (int i = 0; i <= Steps; i++)
        {
            double ratio = (double)i / Steps;
            double h = h1 + (h2 - h1) * ratio;
            double s = s1 + (s2 - s1) * ratio;
            double v = v1 + (v2 - v1) * ratio;

            Colors.Add(ColorTranslator.ToHtml(ColorFromHSV(h, s, v)));
        }
    }

    private static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
    {
        int max = Math.Max(color.R, Math.Max(color.G, color.B));
        int min = Math.Min(color.R, Math.Min(color.G, color.B));

        hue = color.GetHue();
        saturation = (max == 0) ? 0 : 1d - (1d * min / max);
        value = max / 255d;
    }

    private static Color ColorFromHSV(double hue, double saturation, double value)
    {
        int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
        double f = hue / 60 - Math.Floor(hue / 60);

        value *= 255;
        int v = Convert.ToInt32(value);
        int p = Convert.ToInt32(value * (1 - saturation));
        int q = Convert.ToInt32(value * (1 - f * saturation));
        int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

        return hi switch
        {
            0 => Color.FromArgb(255, v, t, p),
            1 => Color.FromArgb(255, q, v, p),
            2 => Color.FromArgb(255, p, v, t),
            3 => Color.FromArgb(255, p, q, v),
            4 => Color.FromArgb(255, t, p, v),
            _ => Color.FromArgb(255, v, p, q),
        };
    }
}
