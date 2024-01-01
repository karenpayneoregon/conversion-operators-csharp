using System.Globalization;

namespace OperatorSamples.Models;
public class Temperature
{
    public float Degrees { get; set; }
    public override string ToString() => Degrees.ToString(CultureInfo.InvariantCulture);

}