using MathGameLibrary.Player;

WelcomeUser();
Player player = new()
{
    PlayerName = GetPlayerName()
};



static void WelcomeUser()
{
    Console.Clear();
    Console.WriteLine();
    Console.WriteLine("Welcome to Math Game v2");
    Console.WriteLine("Designed and developed by Corey Jordan, 2023");
    Console.WriteLine();
}

static string GetPlayerName()
{
    string name = string.Empty;
    Console.Write("Please enter your name, player: ");

    while (name == string.Empty)
    {
        name = Console.ReadLine()!;
        if (name == string.Empty)
        {
            Console.WriteLine("I'm sorry, I didn't quite catch that.");
            Console.Write("PLease eneter your name: ");
        }
    }
    return name;
}