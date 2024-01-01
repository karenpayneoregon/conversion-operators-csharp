namespace OperatorSamples.Models;

public class Celsius : Temperature
{
    public Celsius(float sender)
    {
        Degrees = sender;
    }

    public static implicit operator Fahrenheit(Celsius sender) 
        => new((9.0f / 5.0f) * sender.Degrees + 32);
}