using System;
namespace tictactoe_kata
{
    public class GameLoop
    {
        public bool Run()
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
                Console.WriteLine(tictactoe.OutcomeOf(nextAction));
                if(nextAction == InputAction.ValidMove)
                    tictactoe.SwitchActivePlayer(); //discuss
            } while( nextAction != InputAction.QuitGame && !tictactoe.PlayerHasWon() && !tictactoe.GameIsTie()); 

            return true;
        }        
    }
}