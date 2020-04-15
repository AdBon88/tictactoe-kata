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
        public void Tictactoe_PromptUserForInput_DisplaysInstructions()
        {
            Tictactoe tictactoe = new Tictactoe();

            const string expected = "\nPlayer 1 enter a coord x,y to place your X or enter 'q' to give up:";
            string actual = tictactoe.PromptUserForInput();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Tictactoe_GetUserInput_qEndsProgram()
        {
            Tictactoe tictactoe = new Tictactoe();

            const string expected = "\nPlayer 1 enter a coord x,y to place your X or enter 'q' to give up:";
            string actual = tictactoe.PromptUserForInput();

            Assert.Equal(expected, actual);
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

        [Theory]
        [InlineData("1,1", "\nMove accepted, here's the current board:\n\nX . .\n. . .\n. . .")]
        [InlineData("2,3", "\nMove accepted, here's the current board:\n\n. . .\n. . X\n. . .")]
        [InlineData("3,2", "\nMove accepted, here's the current board:\n\n. . .\n. . .\n. X .")]

        public void Tictactoe_ProcessUserInput_ValidMove_PlacesMarkerOnBoardAtCorrectCoords(string userInput, string expected)
        {
            Tictactoe tictactoe = new Tictactoe();
            
            InputAction validMove = tictactoe.ProcessUserInput(userInput);
            string actual = tictactoe.OutputOf(validMove);

            Assert.Equal(expected, actual);
        }
        

        [Theory]
        [InlineData(InputAction.ValidMove, "\nMove accepted, here's the current board:\n\n. . .\n. . .\n. . .")]
        [InlineData(InputAction.InvalidMove, "\nInvalid move!")]

        public void Tictactoe_OutputOf_nextAction_isCorrect(InputAction nextAction, string expected)
        {
            Tictactoe tictactoe = new Tictactoe();
            
            string actual = tictactoe.OutputOf(nextAction);

            Assert.Equal(expected, actual);
        }

        //TODO - next write test to input a move onto the board
    }
}
