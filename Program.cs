Console.WriteLine("PATH?");
string path = Console.ReadLine();
Console.WriteLine("Content?");
string content = Console.ReadLine();
Console.WriteLine("Token to look for?");
string token = Console.ReadLine();

System.IO.File.WriteAllText(path, content);
string fileContent = System.IO.File.ReadAllText(path);

int cnt = 0;
foreach (var item in fileContent)
{
    if (item.ToString() == token)
        cnt++;
}
Console.WriteLine(cnt);

