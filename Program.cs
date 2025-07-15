using System;
using System.Reflection;

public class Program
{
    static List<Person> people = new List<Person>();  // Make person accessible to Main and changePerson
    static int input = 0;
    static string response = "";



    public static void Main(string[] args)
    {
        List<string> mainUI = ["Add Person", "Show all people", "Edit person"];


        while (true)
        {
            printUI(mainUI, response);
            response = "";
            input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    addPerson();
                    break;
                case 2:
                    response = stringPeople();
                    break;
                case 3:
                    selectPerson();
                    break;
                default:
                    break;
            }

        }
    }
    static void addPerson()
    {
        printUI([""], "Enter name of person: ");
        // System.Console.Write("Enter name of person: ");
        Person tmp = new Person(Console.ReadLine());
        people.Add(tmp);
        response = "new person " + tmp.getName() + " has been added";
    }
    static void selectPerson()
    {
        response = stringPeople();
        printUI([""], response);
        int select = int.Parse(Console.ReadLine()) - 1;
        if (select <= people.Count && select >= 0)
        {
            response = "";
            changePerson(select);
        }
        else
        {
            response = "Select valid number";
        }
    }
    static void printUI(List<string> UI, string response)
    {
        Console.Clear();
        System.Console.WriteLine(response);
        for (int i = 0; i < 4; i++)
        {
            System.Console.WriteLine();
        }


        int cnt = 0;
        foreach (var item in UI)
        {
            if (!item.Equals(""))
            {
                Console.WriteLine(++cnt + ". " + item);
            }
        }
    }
    static string stringPeople()
    {
        int cnt = 0;
        string pp = "";
        foreach (var person in people)
        {
            pp += "\n" + ++cnt + ". " + person.getName();
        }
        cnt = 0;
        return pp;
    }
    static void changePerson(int index)
    {
        while (true)
        {
            try
            {
                List<string> editUI = ["set name", "set age", "get name", "get age", "double age", "Back to main"];

                printUI(editUI, response);
                response = "";
                input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        printUI([""], "Enter name: ");
                        people[index].setName(Console.ReadLine());
                        break;

                    case 2:
                        printUI([""], "Enter age: ");
                        people[index].setAge(int.Parse(Console.ReadLine()));
                        break;

                    case 3:
                        response = "Name: " + people[index].getName();
                        break;

                    case 4:
                        response = "Age: " + people[index].getAge();
                        break;

                    case 5:
                        int age2remember = people[index].getAge();
                        people[index].doubleAge();
                        response = "Age was " + age2remember + " and is now " + people[index].getAge();
                        break;

                    default:
                        return;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong format, try again");
            }
        }
    }
}
