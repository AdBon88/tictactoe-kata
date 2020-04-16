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
        public void Tictactoe_startGame_SetsPlayer1ToActive_Player2IsInactive()
        {
            Tictactoe tictactoe = new Tictactoe();
            tictactoe.StartGame();

            Assert.True(tictactoe.Player1.IsActive && !tictactoe.Player2.IsActive);
        }

        [Fact]
        public void Tictactoe_PromptUserForInput_DisplaysPromptForPlayer1Player1IsActive()
        {
            Tictactoe tictactoe = new Tictactoe();
            tictactoe.Player1.IsActive = true;
            tictactoe.Player2.IsActive = false;

            const string expected = "\nPlayer 1 enter a coord x,y to place your X or enter 'q' to give up:";
            string actual = tictactoe.PromptUserForInput();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Tictactoe_PromptUserForInput_DisplaysPromptForPlayer2Player2IsActive()
        {
            Tictactoe tictactoe = new Tictactoe();
            tictactoe.Player2.IsActive = true;
            tictactoe.Player1.IsActive = false;

            const string expected = "\nPlayer 2 enter a coord x,y to place your O or enter 'q' to give up:";
            string actual = tictactoe.PromptUserForInput();

            Assert.Equal(expected, actual);
        }

       [Fact]
        public void Tictactoe_SwitchActivePlayer_IfPlayer1wasActive_SetsPlayer1ToInActiveAndPlayer2ToActive()
        {
            Tictactoe tictactoe = new Tictactoe();
            tictactoe.Player1.IsActive = true;
            tictactoe.Player2.IsActive = false;

            tictactoe.SwitchActivePlayer();

            Assert.True(!tictactoe.Player1.IsActive && tictactoe.Player2.IsActive);
        }

        [Fact]
        public void Tictactoe_SwitchActivePlayer_IfPlayer2wasActive_SetsPlayer2ToInActiveAndPlayer1ToActive()
        {
            Tictactoe tictactoe = new Tictactoe();
            tictactoe.Player1.IsActive = false;
            tictactoe.Player2.IsActive = true;

            tictactoe.SwitchActivePlayer();

            Assert.True(tictactoe.Player1.IsActive && !tictactoe.Player2.IsActive);
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
            tictactoe.Player1.IsActive = true;
            tictactoe.Player2.IsActive = false;
            
            InputAction validMove = tictactoe.ProcessUserInput(userInput);
            string actual = tictactoe.OutputOf(validMove);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("2,3", "\nMove accepted, here's the current board:\n\n. . .\n. . O\n. . .")]
        [InlineData("3,3", "\nMove accepted, here's the current board:\n\n. . .\n. . .\n. . O")]
        [InlineData("2,2", "\nMove accepted, here's the current board:\n\n. . .\n. O .\n. . .")]
        public void Tictactoe_ProcessUserInput_ValidMove_PlacesActivePlayerMarkerOnBoardAtCorrectCoords(string userInput, string expected)
        {
            Tictactoe tictactoe = new Tictactoe();
            tictactoe.Player1.IsActive = false;
            tictactoe.Player2.IsActive = true;
            
            InputAction validMove = tictactoe.ProcessUserInput(userInput);
            string actual = tictactoe.OutputOf(validMove);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Tictactoe_ProcessUserInput_MoveOnTakenSpace_OutputsSpaceTaken()
        {
            Tictactoe tictactoe = new Tictactoe();
            tictactoe.Board.PlaceMarkerAt("1,1", PlayerMarker.X);

            InputAction unacceptableMove = tictactoe.ProcessUserInput("1,1");
            const string expected = "\nOh no, a piece is already at this place! Try again...";
            string actual = tictactoe.OutputOf(unacceptableMove);

            Assert.Equal(expected, actual);
        }
        

        [Theory]
        [InlineData(InputAction.ValidMove, "\nMove accepted, here's the current board:\n\n. . .\n. . .\n. . .")]
        [InlineData(InputAction.InvalidMove, "\nInvalid move!")]
        [InlineData(InputAction.UnacceptableMove, "\nOh no, a piece is already at this place! Try again...")]

        public void Tictactoe_OutputOf_OutPutIsCorrectForEachAction(InputAction nextAction, string expected)
        {
            Tictactoe tictactoe = new Tictactoe();
            
            string actual = tictactoe.OutputOf(nextAction);

            Assert.Equal(expected, actual);
        }

        //TODO - next write test to input a move onto the board
    }
}
