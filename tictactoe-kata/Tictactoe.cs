using System.Text.RegularExpressions;
using System.Linq;
namespace tictactoe_kata
{
    public class Tictactoe
    {
        public Board Board {get;} = new Board();
        public Player Player1 {get;} = new Player("Player 1", PlayerMarker.X);
        public Player Player2 {get;} = new Player("Player 2", PlayerMarker.O);

        public Player activePlayer {get;set;}

        public string WelcomeMessageOutput()
        {
            return "\nWelcome to Tic Tac Toe!\n\nHere's the current board:";
        }

        public string CurrentBoardOutput()
        {
            return Board.ToString();
        }

        public void StartGame()
        {
            Player1.IsActive = true;
            
        }


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
            switch(userInput)
            {
                case "q":
                    return InputAction.QuitGame;
                case string invalidInput when !Regex.IsMatch(userInput, @"^[1-3],[1-3]$"):
                    return InputAction.InvalidMove;
                case string validCoords when Board.SpaceIsTakenAt(userInput):
                    return InputAction.UnacceptableMove;
                default:
                {
                    if(Player1.IsActive)
                        PlayTurnFor(Player1, userInput);
                    else
                        PlayTurnFor(Player2, userInput);
                    SwitchActivePlayer();
                    return InputAction.ValidMove;
                }     
            }
        }

        private void PlayTurnFor(Player activePlayer, string playerInput){
            Board.PlaceMarkerAt(playerInput, activePlayer.Marker);
        }
        public void SwitchActivePlayer()
        {
            if(Player1.IsActive)
            {
                Player1.IsActive = false;
                Player2.IsActive = true;
            } else if(Player2.IsActive)
            {
                Player2.IsActive =  false;
                Player1.IsActive = true;
            }
        }
        public string OutputOf(InputAction nextAction)
        {
            if (nextAction == InputAction.InvalidMove)
                return InvalidMoveOutput();
            else if (nextAction == InputAction.UnacceptableMove)
                return UnacceptableMoveOutput();
            else
                return MoveAcceptedOutput() + CurrentBoardOutput();
        }
        private string InvalidMoveOutput()
        {
            return "\nInvalid move!";
        }
        private string UnacceptableMoveOutput()
        {
            return "\nOh no, a piece is already at this place! Try again...";
        }

        private string MoveAcceptedOutput()
        {
            return "\nMove accepted, here's the current board:\n";
        }



    }
}