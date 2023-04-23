using MathGameLibrary.Logic;

namespace MathGameLibrary.Player;
public class Player
{
    public string PlayerName { get; set; } = string.Empty;
    public List<Game> GameHistory { get; set; } = new List<Game>();


}
