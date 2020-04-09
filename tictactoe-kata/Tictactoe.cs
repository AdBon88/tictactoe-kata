using System.Text.RegularExpressions;
using System.Linq;
namespace tictactoe_kata
{
    public class Tictactoe
    {
        public string OutputWelcomeMessage()
        {
            return "\nWelcome to Tic Tac Toe!";
        }

        public string OutputCurrentBoard()
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
                return InputAction.QUIT_GAME;
            else if(Regex.IsMatch(userInput, @"^[1-3],[1-3]$"))
                return InputAction.VALID_MOVE;
            else
                return InputAction.INVALID_MOVE;
        }

        public string OutputMoveAcceptedMessage()
        {
            return "\nMove accepted, here's the current board:";
        }

        public string OutputInvalidMoveMessage()
        {
            return "\nInvalid move!";
        }

    }
}