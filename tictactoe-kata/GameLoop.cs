using System;
namespace tictactoe_kata
{
    public class GameLoop
    {
        public bool Run() //is this testable at all?
        {
            Tictactoe tictactoe = new Tictactoe();
            tictactoe.StartGame();
            Console.WriteLine(tictactoe.WelcomeMessageOutput());
            Console.WriteLine(tictactoe.CurrentBoardOutput());
            string userInput = "";
            InputAction nextAction = InputAction.NoMove;
            do
            {
                Console.WriteLine(tictactoe.PromptUserForInput());
                userInput = Console.ReadLine().ToLower();
                nextAction = tictactoe.ProcessUserInput(userInput);
                Console.WriteLine(tictactoe.OutputOf(nextAction));

            } while( nextAction != InputAction.QuitGame ); 

            return true;
        }        
    }
}