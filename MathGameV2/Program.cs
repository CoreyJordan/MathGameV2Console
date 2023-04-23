using MathGameLibrary.Data;
using MathGameLibrary.Logic;
using MathGameLibrary.Player;

WelcomeUser();
Player player = new()
{
    PlayerName = GetPlayerName()
};
Operator gameMode = GetGameMode(player);

PlayRound(player, gameMode);


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
    Console.Clear();
    return name;
}

static Operator GetGameMode(Player player)
{
    string[] options = new [] {"1", "2", "3", "4"};
    string choice;

    do
    {
        Console.WriteLine($"{player.PlayerName}, Choose from the following game types:");
        Console.Write($"1: {Operator.Add}, 2: {Operator.Subtract}, 3: {Operator.Multiply}, 4: {Operator.Divide} ");
        choice = Console.ReadLine()!;
        
        if (!options.Contains(choice))
        {
            Console.WriteLine();
            Console.WriteLine("Sorry, that's not an option. Please try again.");
        }
    } while (!options.Contains(choice));

    Console.Clear();
    return choice switch
    {
        "2" => Operator.Subtract,
        "3" => Operator.Multiply,
        "4" => Operator.Divide,
        _ => Operator.Add
    };
}

void PlayRound(Player player, Operator gameMode)
{
    Game round = new()
    {
        GameType = gameMode,
        NumberOfQuestions = 10,
        IntRange = 100
    };

    for (int i = 0; i < round.NumberOfQuestions; i++)
    {
        Console.Write(round.GenerateProblem());
        int guessNumber = GetPlayerGuess(player);
        bool isCorrect = round.CheckGuess(guessNumber);
    }
}

int GetPlayerGuess(Player player)
{
    int playerGuess;
    string input = Console.ReadLine()!;
    while (!int.TryParse(input, out playerGuess))
    {
        Console.Write($"Sorry {player.PlayerName}, that's not a valid number. Please try again: ");
        input = Console.ReadLine()!;
    }
    return playerGuess;
}