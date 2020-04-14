using System.Text.RegularExpressions;
using System.Linq;
namespace tictactoe_kata
{
    public class Tictactoe
    {
        public Board Board {get;} = new Board();
        public string WelcomeMessageOutput()
        {
            return "\nWelcome to Tic Tac Toe!";
        }

        public string CurrentBoardOutput()
        {
            string[] boardLines = 
            {
                "",
                "Here's the current board:",
                "",
                ". . .",
                ". . .",
                ". . ."
            };         
            return string.Join("\n", boardLines);
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
                return InputAction.ValidMove;
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
            return "\nMove accepted, here's the current board:";
        }

        private string InvalidMoveOutput()
        {
            return "\nInvalid move!";
        }

    }
}