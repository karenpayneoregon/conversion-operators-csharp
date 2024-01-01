using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OperatorSamples.Models;
public class Person  : INotifyPropertyChanged
{
    private int _id;
    private string _firstName;
    private string _lastName;
    private Gender _gender;

    public int Id
    {
        get => _id;
        set
        {
            if (value == _id) return;
            _id = value;
            OnPropertyChanged();
        }
    }

    public string FirstName
    {
        get => _firstName;
        set
        {
            if (value == _firstName) return;
            _firstName = value;
            OnPropertyChanged();
        }
    }

    public string LastName
    {
        get => _lastName;
        set
        {
            if (value == _lastName) return;
            _lastName = value;
            OnPropertyChanged();
        }
    }

    public Gender Gender
    {
        get => _gender;
        set
        {
            if (value == _gender) return;
            _gender = value;
            OnPropertyChanged();
        }
    }

    public override string ToString() => $"{FirstName} {LastName}";

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null!)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}