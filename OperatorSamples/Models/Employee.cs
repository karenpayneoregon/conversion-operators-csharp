namespace OperatorSamples.Models;

public class Employee : Person
{
    private decimal _monthlySalary;

    public Employee(int id, string firstName, string lastName, Gender gender, decimal monthlySalary)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        MonthlySalary = monthlySalary;
    }

    public decimal MonthlySalary
    {
        get => _monthlySalary;
        set
        {
            if (value == _monthlySalary) return;
            _monthlySalary = value;
            OnPropertyChanged();
        }
    }

    public static implicit operator Employee(Contractor contractEmployee)
    {
        // Convert Contract to Employee
        decimal monthlySalary = contractEmployee.HourlyRate * 160; // 160 working hours in a month
        return new Employee(contractEmployee.Id, contractEmployee.FirstName,contractEmployee.LastName, contractEmployee.Gender, monthlySalary);
    }
}