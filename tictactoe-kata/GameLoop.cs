using System;
namespace tictactoe_kata
{
    public class GameLoop
    {
        public bool Run()
        {
            Tictactoe tictactoe = new Tictactoe();
            Console.WriteLine(tictactoe.OutputWelcomeMessage());
            Console.WriteLine(tictactoe.OutputCurrentBoard());

            string userInput = "";
            InputAction nextAction = InputAction.NO_MOVE;
            do
            {
                Console.WriteLine(tictactoe.PromptUserForInput());
                userInput = Console.ReadLine().ToLower();
                nextAction = tictactoe.ProcessUserInput(userInput);
                if (nextAction != InputAction.QUIT_GAME)
                    Console.WriteLine(tictactoe.OutputCurrentBoard());

            } while( nextAction != InputAction.QUIT_GAME );

            return true;
        }        
    }
}