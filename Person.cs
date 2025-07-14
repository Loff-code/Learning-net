public class Person
{
    private string name;
    private int age;
    public Person() { }
    public void setName(string name)
    {
        this.name = name;
    }
    public void setAge(int age)
    {
        this.age = age;
    }

    public string getName()
    {
        return name;
    }
    public int getAge()
    {
        return age;
    }

    public void doubleAge()
    {
        age *= 2;
    }

}