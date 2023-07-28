var pCharacters = new Dictionary<int, string>()
{
    {0, "acbdefghjklmnoprstuvyzwxq"}, 
    {1, "ABCDEFGHJKLMNOPRSTUVYZWXQ"}, 
    {2, "0123456789"}, 
    {3, "!'^#+$£%&/{([)]=}?_|@"}
};

while (true)
{
    Send("Enter password length: ", false, ConsoleColor.Green);
    var input = Console.ReadLine();
    
    if (!uint.TryParse(input, out var lenght))
    {
        Send("Invalid length !", true, ConsoleColor.Red);
        continue;
    }
    
    var random = new Random();
    var pArray = new char[lenght];

    for (uint i = 0; i < lenght; i++)
    {
        var _1 = random.Next(pCharacters.Count);
        var _2 = random.Next(pCharacters[_1].Length);
        pArray[i] = pCharacters[_1][_2];
    }

    var password = new string(pArray);
    
    Send("Password: ", false, ConsoleColor.DarkCyan);
    Send(password, true, ConsoleColor.Magenta);

    string status;
    
    while (true)
    {
        Send("Exit: ", false, ConsoleColor.White);
        Send("0", false, ConsoleColor.Red);
        Send(", Continue: ", false, ConsoleColor.White);
        Send("1", true, ConsoleColor.Green);
        
        status = Console.ReadLine();
        if (status == "1" || status == "0") break;

        Send("Invalid input.", true, ConsoleColor.Red);
    }
    
    if (status == "0") break;
}

static void Send(string message, bool line, ConsoleColor color)
{
    Console.ForegroundColor = color;
    if (line) 
        Console.WriteLine(message);
    else 
        Console.Write(message);
    Console.ResetColor();
}