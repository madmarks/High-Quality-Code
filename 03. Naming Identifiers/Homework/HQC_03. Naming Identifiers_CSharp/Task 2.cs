public class Program
{
    public enum Gender 
    { 
        Male, Female 
    }
    
    public void MakePerson(int uniqueId)
    {
        Person person = new Person();
        
        person.Age = uniqueId;
        
        if (uniqueId % 2 == 0)
        {
            person.Name = "Батката";
            person.Gender = Gender.Male;
        }
        else
        {
            person.Name = "Мацето";
            person.Gender = Gender.Female;
        }
    }

    protected class Person
    {
        public Gender Gender { get; set; }
        
        public string Name { get; set; }
        
        public int Age { get; set; }
    }
}