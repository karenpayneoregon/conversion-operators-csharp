namespace OperatorSamples.Models;

public class Fahrenheit : Temperature
{
    public Fahrenheit(float sender)
    {
        Degrees = sender;
    }

    public static implicit operator Celsius(Fahrenheit sender) 
        => new((5.0f / 9.0f) * (sender.Degrees - 32));
}