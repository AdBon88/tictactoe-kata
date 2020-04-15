using System.Runtime.CompilerServices;
namespace tictactoe_kata
{
    public class Player
    {
        public string Name {get;}
        public PlayerMarker Marker {get;}
        public bool IsActive {get; set;}

        public Player(string name, PlayerMarker marker, bool isActive)
        {
            Name = name;
            Marker = marker;
            IsActive = isActive;
        }
    }
}