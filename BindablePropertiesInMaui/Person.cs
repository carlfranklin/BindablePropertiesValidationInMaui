namespace BindablePropertiesInMaui;

public class Person
{
    public Person(int id, string firstName, string lastName, DateTime dateOfBirth)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
    }

    public int Id { get; set; }

    public string _firstName;
    public string FirstName
    {
        get => _firstName;
        set
        {
            // I exposed the setter so you can put a break point here
            // proving that property values change in this vanilla class.
            _firstName = value;
        }
    }

    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
}