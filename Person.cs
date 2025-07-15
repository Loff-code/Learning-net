
public class Person
{
    private string name;
    private int age;
    public static int count = 0;
    public Person(string name)
    {
        count++;
        this.name = name;
    }
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