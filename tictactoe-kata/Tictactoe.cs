using System.Text.RegularExpressions;
using System.Linq;
namespace tictactoe_kata
{
    public class Tictactoe
    {
        public Board Board {get;} = new Board();
        public string WelcomeMessageOutput()
        {
            return "\nWelcome to Tic Tac Toe!\n\nHere's the current board:";
        }

        public string CurrentBoardOutput()
        {
            return Board.ToString();
        }


        public string PromptUserForInput()
        {
            return "\nPlayer 1 enter a coord x,y to place your X or enter 'q' to give up:";
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