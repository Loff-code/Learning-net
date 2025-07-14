Console.Write("How many names? ");
int cnt = int.Parse(Console.ReadLine());
Console.Write("\n");
List<string> list = new List<string>();
for (int i = 0; i < cnt; i++)
{
    Console.Write("Enter Name: ");
    list.Add(Console.ReadLine());
}

foreach (var item in list)
{
Console.WriteLine("Hello, " + item + "!");
}
