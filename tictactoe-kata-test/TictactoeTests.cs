using System;
using Xunit;
using tictactoe_kata;

namespace tictactoe_kata_test
{
    public class Tictactoetests
    {
        [Fact]
        public void Tictactoe_WelcomeMessageOutput_OutputsWelcomeToTicTacToe()
        {
            Tictactoe tictactoe = new Tictactoe();

            const string expected = "\nWelcome to Tic Tac Toe!\n\nHere's the current board:";
            string actual = tictactoe.WelcomeMessageOutput();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Tictactoe_CurrentBoardOutput_OutputsNewBoard()
        {
            Tictactoe tictactoe = new Tictactoe();
            const string expected ="\n"
                + ". . .\n"
                + ". . .\n"
                + ". . .";

            string actual = tictactoe.CurrentBoardOutput();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Tictactoe_startGame_SetsPlayer1AsActivePlayer()
        {
            Tictactoe tictactoe = new Tictactoe();
            tictactoe.StartGame();

            const string expected = "Player 1";
            string actual = tictactoe.ActivePlayer.Name;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Tictactoe_PromptUserForInput_DisplaysPromptForPlayer1IfPlayer1sTurn()
        {
            Tictactoe tictactoe = new Tictactoe();
            tictactoe.StartGame();

            const string expected = "\nPlayer 1 enter a coord x,y to place your X or enter 'q' to give up:";
            string actual = tictactoe.PromptUserForInput();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Tictactoe_PromptUserForInput_DisplaysPromptForPlayer2IfPlayer2sTurn()
        {
            Tictactoe tictactoe = new Tictactoe();
            tictactoe.StartGame();
            tictactoe.SwitchActivePlayer();

            const string expected = "\nPlayer 2 enter a coord x,y to place your O or enter 'q' to give up:";
            string actual = tictactoe.PromptUserForInput();

            Assert.Equal(expected, actual);
        }

       [Fact]
        public void Tictactoe_SwitchActivePlayer_IfPlayer1wasActive_SetsActivePlayerAsPlayer2()
        {
            Tictactoe tictactoe = new Tictactoe();
            tictactoe.ActivePlayer = tictactoe.Player1;

            tictactoe.SwitchActivePlayer();
            const string expected = "Player 2";
            string actual = tictactoe.ActivePlayer.Name;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Tictactoe_SwitchActivePlayer_IfPlayer2wasActive_SetsActivePlayerAsPlayer1()
        {
            Tictactoe tictactoe = new Tictactoe();
            tictactoe.ActivePlayer = tictactoe.Player2;

            tictactoe.SwitchActivePlayer();
            const string expected = "Player 1";
            string actual = tictactoe.ActivePlayer.Name;

            Assert.Equal(expected, actual);
        }

        [Theory]
        //[InlineData(InputAction.ValidMove, "\nMove accepted, here's the current board:\n\n. . .\n. . .\n. . .")]
        [InlineData(InputAction.InvalidMove, "\nInvalid move!")]
        [InlineData(InputAction.UnacceptableMove, "\nOh no, a piece is already at this place! Try again...")]

        public void Tictactoe_OutcomeOf_EachActionHasCorrectOutcome(InputAction nextAction, string expected)
        {
            Tictactoe tictactoe = new Tictactoe();
            
            string actual = tictactoe.OutcomeOf(nextAction);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1,1", "1,2", "1,3")] //top row
        [InlineData("2,1", "2,2", "2,3")] //middle row
        [InlineData("3,1", "3,2", "3,3")] //bottom row

        public void Tictactoe_PlayerHasWon_If3MarkersOfAPlayerInARow(string coords1, string coords2, string coords3)
        {
            Tictactoe tictactoe = new Tictactoe();
            tictactoe.ActivePlayer = tictactoe.Player1;
            
            tictactoe.Board.PlaceMarkerAt(coords1, PlayerMarker.X);
            tictactoe.Board.PlaceMarkerAt(coords2, PlayerMarker.X);
            tictactoe.Board.PlaceMarkerAt(coords3, PlayerMarker.X);

            Assert.True(tictactoe.PlayerHasWon());
        }

        [Theory]
        [InlineData("1,1", "2,1", "3,1")] //left col
        [InlineData("1,2", "2,2", "3,2")] //middle col
        [InlineData("1,3", "2,3", "3,3")] //right row

        public void Tictactoe_PlayerHasWon_If3MarkersOfAPlayerInACol(string coords1, string coords2, string coords3)
        {
            Tictactoe tictactoe = new Tictactoe();
            tictactoe.ActivePlayer = tictactoe.Player2;
            tictactoe.Board.PlaceMarkerAt(coords1, PlayerMarker.O);
            tictactoe.Board.PlaceMarkerAt(coords2, PlayerMarker.O);
            tictactoe.Board.PlaceMarkerAt(coords3, PlayerMarker.O);

            Assert.True(tictactoe.PlayerHasWon());
        }
        [Theory]
        [InlineData("1,1", "2,2", "3,3")] //top to bottom diagonal
        [InlineData("1,3", "2,2", "3,1")] //bottom to top diagonal

        public void Tictactoe_PlayerHasWon_If3MarkersOfAPlayerInADiagonal(string coords1, string coords2, string coords3)
        {
            Tictactoe tictactoe = new Tictactoe();
            tictactoe.ActivePlayer = tictactoe.Player1;
            tictactoe.Board.PlaceMarkerAt(coords1, PlayerMarker.X);
            tictactoe.Board.PlaceMarkerAt(coords2, PlayerMarker.X);
            tictactoe.Board.PlaceMarkerAt(coords3, PlayerMarker.X);

            Assert.True(tictactoe.PlayerHasWon());
        }

        [Theory]
        [InlineData("1,1", InputAction.ValidMove)]
        [InlineData("13,2", InputAction.InvalidMove)]
        [InlineData("3,24", InputAction.InvalidMove)]
        [InlineData("dasdad", InputAction.InvalidMove)]
        [InlineData("q", InputAction.QuitGame)]
        public void Tictactoe_ProcessUserInput_ReturnsAppropriateInputActionEnum(string userInput, InputAction expected)
        {
            Tictactoe tictactoe = new Tictactoe();
            tictactoe.ActivePlayer = tictactoe.Player1;
            
            InputAction actual = tictactoe.ProcessUserInput(userInput);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Tictactoe_ProcessUserInput_UnacceptableMoveIfSpaceAlreadyTaken()
        {
            Tictactoe tictactoe = new Tictactoe();
            tictactoe.Board.PlaceMarkerAt("1,1", PlayerMarker.X);

            const InputAction expected = InputAction.UnacceptableMove;
            InputAction actual = tictactoe.ProcessUserInput("1,1");

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1,1", "\nMove accepted, here's the current board:\n\nX . .\n. . .\n. . .")]
        [InlineData("2,3", "\nMove accepted, here's the current board:\n\n. . .\n. . X\n. . .")]
        [InlineData("3,2", "\nMove accepted, here's the current board:\n\n. . .\n. . .\n. X .")]
        public void Tictactoe_ProcessUserInput_ValidMove_Player1IsActive_PlacesXMarkerOnBoardAtCorrectCoords(string userInput, string expected)
        {
            Tictactoe tictactoe = new Tictactoe();
            tictactoe.ActivePlayer = tictactoe.Player1;
            
            InputAction validMove = tictactoe.ProcessUserInput(userInput);
            string actual = tictactoe.OutcomeOf(validMove);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("2,3", "\nMove accepted, here's the current board:\n\n. . .\n. . O\n. . .")]
        [InlineData("3,3", "\nMove accepted, here's the current board:\n\n. . .\n. . .\n. . O")]
        [InlineData("2,2", "\nMove accepted, here's the current board:\n\n. . .\n. O .\n. . .")]
        public void Tictactoe_ProcessUserInput_ValidMove_Player2IsActive_PlacesOMarkerOnBoardAtCorrectCoords(string userInput, string expected)
        {
            Tictactoe tictactoe = new Tictactoe();
            tictactoe.ActivePlayer = tictactoe.Player2;

            InputAction validMove = tictactoe.ProcessUserInput(userInput);
            string actual = tictactoe.OutcomeOf(validMove);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Tictactoe_ProcessUserInput_MoveOnTakenSpace_OutputsSpaceTaken()
        {
            Tictactoe tictactoe = new Tictactoe();
            tictactoe.Board.PlaceMarkerAt("1,1", PlayerMarker.X);

            InputAction unacceptableMove = tictactoe.ProcessUserInput("1,1");
            const string expected = "\nOh no, a piece is already at this place! Try again...";
            string actual = tictactoe.OutcomeOf(unacceptableMove);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Tictactoe_ProcessUserInput_LastSpaceIsTaken_NoWin_OutputsDraw()
        {
            Tictactoe tictactoe = new Tictactoe();
            tictactoe.ActivePlayer = tictactoe.Player1;
            // Simulate a stalement situation:
            // X X O
            // O O X
            // X O .
            tictactoe.ProcessUserInput("1,1"); //X's move
            tictactoe.SwitchActivePlayer();
            tictactoe.ProcessUserInput("1,3"); //O's move
            tictactoe.SwitchActivePlayer();
            tictactoe.ProcessUserInput("1,2"); //X's move
            tictactoe.SwitchActivePlayer();
            tictactoe.ProcessUserInput("2,1"); //O's move
            tictactoe.SwitchActivePlayer();
            tictactoe.ProcessUserInput("2,3"); //X's move
            tictactoe.SwitchActivePlayer();
            tictactoe.ProcessUserInput("2,2"); //O's move
            tictactoe.SwitchActivePlayer();
            tictactoe.ProcessUserInput("3,1"); //X's move
            tictactoe.SwitchActivePlayer();
            tictactoe.ProcessUserInput("3,2"); //O's move
            tictactoe.SwitchActivePlayer();

            InputAction tieMove = tictactoe.ProcessUserInput("3,3"); //X's move
            const string expected = "\nMove accepted, it's a tie!\n"
                + "\n"
                + "X X O\n"
                + "O O X\n"
                + "X O X";

            string actual = tictactoe.OutcomeOf(tieMove);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Tictactoe_ProcessUserInput_ThreeMarkersConsecutiveMarkers_InRow_OutputsWin()
        {
            Tictactoe tictactoe = new Tictactoe();
            tictactoe.ActivePlayer = tictactoe.Player1;
            // Simulate Player 2 (O) winning the game:
            // O O O
            // . X X
            // X . .
            tictactoe.ProcessUserInput("2,2"); //X's move
            tictactoe.SwitchActivePlayer();
            tictactoe.ProcessUserInput("1,1"); //O's move
            tictactoe.SwitchActivePlayer();
            tictactoe.ProcessUserInput("2,3"); //X's move
            tictactoe.SwitchActivePlayer();
            tictactoe.ProcessUserInput("1,2"); //O's move
            tictactoe.SwitchActivePlayer();
            tictactoe.ProcessUserInput("3,1"); //X's move
            tictactoe.SwitchActivePlayer();

            InputAction winningMove = tictactoe.ProcessUserInput("1,3"); //O's move
            const string expected = "\nMove accepted, well done you've won the game!\n"
                + "\n"
                + "O O O\n"
                + ". X X\n"
                + "X . .";

            string actual = tictactoe.OutcomeOf(winningMove);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Tictactoe_ProcessUserInput_ThreeMarkersConsecutiveMarkers_AnyDirection_OutputsWin()
        {
            Tictactoe tictactoe = new Tictactoe();
            tictactoe.ActivePlayer = tictactoe.Player1;
            // Simulate Player 1 (X) winning the game:
            // X O X
            // O X O
            // O X X

            //Don't actually need this, can just set the board state and active player
            tictactoe.ProcessUserInput("1,1"); //X's move
            tictactoe.SwitchActivePlayer();
            tictactoe.ProcessUserInput("1,2"); //O's move
            tictactoe.SwitchActivePlayer();
            tictactoe.ProcessUserInput("1,3"); //X's move
            tictactoe.SwitchActivePlayer();
            tictactoe.ProcessUserInput("2,1"); //O's move
            tictactoe.SwitchActivePlayer();
            tictactoe.ProcessUserInput("2,2"); //X's move
            tictactoe.SwitchActivePlayer();
            tictactoe.ProcessUserInput("2,3"); //O's move
            tictactoe.SwitchActivePlayer();
            tictactoe.ProcessUserInput("3,2"); //X's move
            tictactoe.SwitchActivePlayer();
            tictactoe.ProcessUserInput("3,1"); //O's move
            tictactoe.SwitchActivePlayer();

            InputAction winningMove = tictactoe.ProcessUserInput("3,3"); //X's move
            const string expected = "\nMove accepted, well done you've won the game!\n"
                + "\n"
                + "X O X\n"
                + "O X O\n"
                + "O X X";

            string actual = tictactoe.OutcomeOf(winningMove);

            Assert.Equal(expected, actual);
        }
    }


}
