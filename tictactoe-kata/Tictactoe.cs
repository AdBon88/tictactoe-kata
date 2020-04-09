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
            else
                return InputAction.VALID_MOVE;
        }
    }
}