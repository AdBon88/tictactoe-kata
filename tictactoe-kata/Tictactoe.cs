using System;
using System.Text.RegularExpressions;
using System.Linq;
namespace tictactoe_kata
{
    public class Tictactoe
    {
        public const int MaxAllowedMoves = 9;
        public Board Board {get;} = new Board();
        public Player Player1 {get;} = new Player("Player 1", PlayerMarker.X);
        public Player Player2 {get;} = new Player("Player 2", PlayerMarker.O);
        public Player ActivePlayer{get; set;}
        public int MoveCount {get; set;} = 0;

        public string WelcomeMessageOutput()
        {
            return "\nWelcome to Tic Tac Toe!\n\nHere's the current board:";
        }

        public void StartGame()
        {
            ActivePlayer = Player1;
        }

        public string PromptUserForInput()
        {
            return $"\n{ActivePlayer.Name} enter a coord x,y to place your {(char)ActivePlayer.Marker} or enter 'q' to give up:";
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
                    PlayTurnAtCoords(userInput);
                    return InputAction.ValidMove;
            }
        }
        private void PlayTurnAtCoords(string playerInput){
            Board.PlaceMarkerAt(playerInput, ActivePlayer.Marker);
            MoveCount ++;
        }
        public string OutcomeOf(InputAction nextAction)
        {
            switch(nextAction)
            {
                case InputAction.InvalidMove:
                    return InvalidMoveOutput();
                case InputAction.UnacceptableMove:
                    return UnacceptableMoveOutput();
                default: //would be more readable if i didn't have a default and had case inputaction.ValidMove
                    return RoundOutcome();
            }
        }

        private string RoundOutcome()
        {
            if(PlayerHasWon())
                return WinningMoveOutput() + CurrentBoardOutput();
            else if (GameIsTie())
                return TieMoveOutput() + CurrentBoardOutput();
            else
                return MoveAcceptedOutput() + CurrentBoardOutput();
        }

        public bool PlayerHasWon()
        { 
            string winningSequence = (ActivePlayer.Name == Player1.Name) ? "XXX" : "OOO";

            if (PlayerHasWinningRowWith(winningSequence))
                return true;
            if (PlayerHasWinningColWith(winningSequence))
                return true;
            if (PlayerHasWinningDiagonalWith(winningSequence))
                return true;
            return false;
        }

        public bool GameIsTie()
        {
            if (MoveCount == MaxAllowedMoves && !PlayerHasWon())
                return true;
            return false;
        }
        private bool PlayerHasWinningRowWith(string winningSequence)
        {
            for (int i = 0; i < Board.NumberOfRows; i++)
            {
                string row = "";
                for (int j = 0; j < Board.NumberOfCols; j++)
                    row += Board.SpaceContents[i,j].ToString();
                
                if(row.Contains(winningSequence))
                    return true;
            }
            return false;
        }

        private bool PlayerHasWinningColWith(string winningSequence)
        {
            string leftCol = "";
            string midCol = "";
            string rightCol = "";

            for (int i = 0; i < Board.NumberOfRows; i++)
            {
                leftCol += Board.SpaceContents[i,0].ToString();
                midCol += Board.SpaceContents[i,1].ToString();
                rightCol += Board.SpaceContents[i,2].ToString();
            }

            if( leftCol.Contains(winningSequence) || midCol.Contains(winningSequence) || rightCol.Contains(winningSequence) )
                return true;
                
            return false;
        }

        private bool PlayerHasWinningDiagonalWith(string threePlayerMarkers)
        {
            string topToBottomDiagonal = Board.SpaceContents[0,0].ToString() + Board.SpaceContents[1,1].ToString() + Board.SpaceContents[2,2].ToString();
            string bottomToTopDiagonal = Board.SpaceContents[0,2].ToString() + Board.SpaceContents[1,1].ToString() + Board.SpaceContents[2,0].ToString();

            if( topToBottomDiagonal.Contains(threePlayerMarkers) || bottomToTopDiagonal.Contains(threePlayerMarkers))
                return true;
                
            return false;
        }
        public void SwitchActivePlayer()
        {
            ActivePlayer = (ActivePlayer.Name == Player1.Name) ? Player2 : Player1;
        }

        public string CurrentBoardOutput()
        {
            return Board.ToString();
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
        private string TieMoveOutput()
        {
            return "\nMove accepted, it's a tie!\n";
        }
        private string WinningMoveOutput()
        {
            return "\nMove accepted, well done you've won the game!\n";
        }
    }
}