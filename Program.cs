Person person = new Person();
int input = 0;

while (true)
{
    try
    {
        System.Console.WriteLine("\n1. set name \n2. set age \n3. get name \n4. get age\n5. double age");
        input = int.Parse(Console.ReadLine());
        switch (input)
        {
            case 1:
                person.setName(Console.ReadLine());
                break;
            case 2:
                person.setAge(int.Parse(Console.ReadLine()));
                break;
            case 3:
                System.Console.WriteLine(person.getName());
                break;
            case 4:
                System.Console.WriteLine(person.getAge());
                break;
            case 5:
                int age2remember = person.getAge();
                person.doubleAge();
                System.Console.WriteLine("Age was " + age2remember + " and is now " + person.getAge());
                break;
            default:
                break;
        }


    }
    catch (System.FormatException)
    {
        System.Console.WriteLine("Wrong format, try again");
        throw;
    }

}