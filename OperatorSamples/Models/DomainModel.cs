namespace OperatorSamples.Models;
public class Human
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
}

public class Dto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public static implicit operator Dto(Human sender) => new()
        {
            Id = sender.Id,
            FirstName = sender.FirstName,
            LastName = sender.LastName
        };
}

public static class Demo
{
    public static void Run()
    {
        Human human = new()
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            BirthDate = new DateOnly(1970, 1, 1)
        };

        Dto dto = human;
    }
}


