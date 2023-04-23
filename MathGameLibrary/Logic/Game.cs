using MathGameLibrary.Data;

namespace MathGameLibrary.Logic;
public class Game
{
    public Operator GameType { get; set; }
    public int NumberOfQuestions { get; set; }
    public int IntRange { get; set; }
    public int Number1 { get; private set; }
    public int Number2 { get; private set; }
    public char OperatorSymbol { get; private set; }


    public string GenerateProblem()
    {
        Random random = new();
        Number1 = random.Next(IntRange) + 1;
        Number2 = random.Next(IntRange) + 1;
        OperatorSymbol = GetSymbol();

        if (GameType == Operator.Divide)
        {
            while (Number1 % Number2 != 0)
            {
                Number1 = random.Next(IntRange) + 1;
                Number2 = random.Next(IntRange) + 1;
            }
        }
        return $"{Number1} {OperatorSymbol} {Number2} = ";
    }
    private char GetSymbol()
    {
        return GameType switch
        {
            Operator.Subtract => '-',
            Operator.Multiply => '*',
            Operator.Divide => '/',
            _ => '+'
        };
    }
}
