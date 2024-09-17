public class Person {
    private string firstName { get; set; }
    private string lastName { get; set; }
    private int age;

    public Person(string firstName, string lastName, int age = 18){
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    public Person(){
        this.firstName = "";
        this.lastName = "";
        this.age = 18;
    }

    public override string ToString(){
        return $"{FirstName} {LastName} wiek: {Age}";
    }

    public string FirstName {
        get { return firstName.ToUpper(); }
        set { firstName = value; }
    }

    public string LastName {
        get { return lastName; }
        set { lastName = value; }
    }

    public int Age {
        get { return age; }
        set { age = value < 0 ? -value : value; }
    }
}
