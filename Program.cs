using System;
using System.Reflection;

public class Program
{
    static List<Professor> professors = new List<Professor>();
    static List<Student> students = new List<Student>();
    static CourseRepository courseRepo = new CourseRepository();

    static int input = 0;
    static string response = "";



    public static void Main(string[] args)
    {
        List<string> mainUI = new List<string>
{
    "Add Professor", "Add Student", "Show all people", "Edit Professor", "Edit Student", "Show people count", "Show all courses", "Add Course", "Enroll student in course", "Show a student's enrolled courses"
};
        while (true)
        {
            printUI(mainUI, response);
            response = "";
            input = getInt();
            switch (input)
            {
                case 1:
                    addProfessor();
                    break;
                case 2:
                    addStudent();
                    break;
                case 3:
                    showAllPeople();
                    break;
                case 4:
                    selectPerson(professors.Cast<Person>().ToList());
                    break;
                case 5:
                    selectPerson(students.Cast<Person>().ToList());
                    break;
                case 6:
                    response = $"Total count of people created: {Person.count}";
                    break;
                case 7:
                    foreach (var course in courseRepo.GetAll())
                    {
                        response += $"[{course.CourseId}] {course.Title} ({course.ECTS})\n";
                    }
                    break;
                case 8:
                    courseRepo.addCourse(new Course(getInt(), Console.ReadLine(), getInt()));
                    break;
                case 9:
                    enrollStudentInCourse(selectStudent(students));
                    break;
                case 10:
                    showStudentCourses(selectStudent(students));
                    break;
                default:
                    break;
            }

        }
    }





    static void showAllPeople()
    {
        var allPeople = new List<Person>();
        allPeople.AddRange(professors);
        allPeople.AddRange(students);
        response = stringPeople(allPeople);

    }
    static int getInt()
    {
        int output = int.Parse(Console.ReadLine());
        return output;
    }
    static void addProfessor()
    {
        printUI([""], "Enter name of professor: ");
        Professor tmp = new Professor(Console.ReadLine());
        professors.Add(tmp);
        response = "new professor " + tmp.getName() + " has been added";
    }

    static void addStudent()
    {
        printUI([""], "Enter name of student: ");
        Student tmp = new Student(Console.ReadLine());
        students.Add(tmp);
        response = "new Student " + tmp.getName() + " has been added";
    }
    static void showStudentCourses(Student student)
    {
        List<string> studentCourses = new List<string>();
        foreach (var courseId in student.EnrolledCourseIds)
        {
            var course = courseRepo.GetById(courseId);
            if (course != null)
            {
                studentCourses.Add($"[{course.CourseId}] {course.Title} ({course.ECTS})\n");
            }
        }

        printUI(studentCourses, $"Student {student.getName()} is currently enrolled in:");
        Console.ReadLine();
    }
    static void enrollStudentInCourse(Student student)
    {
        List<string> tmp = new List<string>();
        foreach (var course in courseRepo.GetAll())
        {
            tmp.Add($"[{course.CourseId}] {course.Title} ({course.ECTS})\n");
        }
        response = "Select course:";


        printUI(tmp, response);
        int select = getInt() - 1;
        if (select >= 0 && select < courseRepo.GetAll().Count)
        {
            Course course = courseRepo.GetAll()[select];
            student.EnrollInCourse(course.CourseId);
            response = $"Student {student.getName()} has been enrolled into [{course.CourseId}] {course.Title} ({course.ECTS})\n";
        }
        else
        {
            response = "Select valid number";
        }


    }
    static Student selectStudent(List<Student> students)
    {
        printUI(new List<string> { "" }, stringPeople(students.Cast<Person>().ToList()));
        int select = getInt() - 1;
        if (select >= 0 && select < students.Count)
        {
            response = "";
            return students[select];
        }
        else
        {
            response = "Select valid number";
            return null;
        }
        throw new Exception();
    }
    static void selectPerson(List<Person> people)
    {
        printUI(new List<string> { "" }, stringPeople(people));
        int select = getInt() - 1;
        if (select >= 0 && select < people.Count)
        {
            response = "";
            changePerson(select, people);
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
    static string stringPeople(List<Person> people)
    {
        int cnt = 0;
        string pp = "";
        foreach (var person in people)
        {
            pp += "\n" + ++cnt + ". " + person.getName();
        }
        return pp;
    }

    static void changePerson(int index, List<Person> people)
    {
        while (true)
        {
            try
            {
                List<string> editUI = ["set name", "set age", "get name", "get age", "double age", "Back to main"];

                printUI(editUI, response);
                response = "";
                input = getInt();

                switch (input)
                {
                    case 1:
                        printUI([""], "Enter name: ");
                        people[index].setName(Console.ReadLine());
                        break;

                    case 2:
                        printUI([""], "Enter age: ");
                        people[index].setAge(getInt());
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
