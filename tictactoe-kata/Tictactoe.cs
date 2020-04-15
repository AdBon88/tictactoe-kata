using System.Text.RegularExpressions;
using System.Linq;
namespace tictactoe_kata
{
    public class Tictactoe
    {
        public Board Board {get;} = new Board();
        public Player Player1 {get;} = new Player("Player 1", PlayerMarker.X, true);
        public Player Player2 {get;} = new Player("Player 2", PlayerMarker.O, false);


        public string WelcomeMessageOutput()
        {
            return "\nWelcome to Tic Tac Toe!\n\nHere's the current board:";
        }

        public string CurrentBoardOutput()
        {
            return Board.ToString();
        }

        // public void SwitchActivePlayer()
        // {
        //     if(!Player1.IsActive && !Player2.IsActive)
        //         Player1.IsActive = true;
        //     else 
        // }

        //TODO ASK ABOUT THIS
        public string PromptUserForInput()
        {
            string playerName = "";
            char playerMarker = ' ';

            if (Player1.IsActive)
            {
                playerName = Player1.Name;
                playerMarker = (char)Player1.Marker;
            } else if (Player2.IsActive)
            {
                playerName = Player2.Name;
                playerMarker = (char)Player2.Marker;
            }
            return $"\n{playerName} enter a coord x,y to place your {playerMarker} or enter 'q' to give up:";
        }

        public InputAction ProcessUserInput(string userInput)
        {
            if(userInput == "q")
                return InputAction.QuitGame;
            else if(Regex.IsMatch(userInput, @"^[1-3],[1-3]$"))
            {
                Board.PlaceMarkerAt(userInput);
                return InputAction.ValidMove;
            }
            else
                return InputAction.InvalidMove;
        }

        public string OutputOf(InputAction nextAction)
        {
            if (nextAction == InputAction.ValidMove)
                return MoveAcceptedOutput() + CurrentBoardOutput();
            else
                return InvalidMoveOutput();
        }

        private string MoveAcceptedOutput()
        {
            return "\nMove accepted, here's the current board:\n";
        }

        private string InvalidMoveOutput()
        {
            return "\nInvalid move!";
        }

    }
}