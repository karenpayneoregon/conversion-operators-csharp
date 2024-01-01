namespace OperatorSamples.Models;

public class Contractor : Person
{
    private decimal _hourlyRate;

    public Contractor()
    {
    }

    public Contractor(int id, string firstName, string lastName, Gender gender, decimal hourlyRate)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        HourlyRate = hourlyRate;
    }

    public decimal HourlyRate
    {
        get => _hourlyRate;
        set
        {
            if (value == _hourlyRate) return;
            _hourlyRate = value;
            OnPropertyChanged();
        }
    }
}