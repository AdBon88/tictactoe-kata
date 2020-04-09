using System;
using Xunit;
using tictactoe_kata;

namespace tictactoe_kata_test
{
    public class Tictactoetests
    {
        [Fact]
        public void Tictactoe_DisplayWelcomeMessage_DisplaysWelcomeToTicTacToe()
        {
            Tictactoe tictactoe = new Tictactoe();

            const string expected = "\nWelcome to Tic Tac Toe!";
            string actual = tictactoe.OutputWelcomeMessage();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Tictactoe_DisplayBoard_DisplaysNewBoard()
        {
            Tictactoe tictactoe = new Tictactoe();
            const string expected = "\nHere's the current board:\n"
                + "\n"
                + ". . .\n"
                + ". . .\n"
                + ". . .";

            string actual = tictactoe.OutputCurrentBoard();

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
        [InlineData("1,1", InputAction.VALID_MOVE)]
        [InlineData("13,2", InputAction.INVALID_MOVE)]
        [InlineData("3,24", InputAction.INVALID_MOVE)]
        [InlineData("dasdad", InputAction.INVALID_MOVE)]
        [InlineData("q", InputAction.QUIT_GAME)]

        public void Tictactoe_ProcessUserInput_ReturnsAppropriateInputActionEnum(string userInput, InputAction expected)
        {
            Tictactoe tictactoe = new Tictactoe();
            
            InputAction actual = tictactoe.ProcessUserInput(userInput);

            Assert.Equal(expected, actual);
        }
        //TODO ask about this!!!!
        [Fact]
        public void Tictactoe_OutputMoveAcceptedMessage_OutputsCorrectMessage()
        {
            Tictactoe tictactoe = new Tictactoe();

            const string expected = "\nMove accepted, here's the current board:";
            string actual = tictactoe.OutputMoveAcceptedMessage();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Tictactoe_OutputInvalidMoveMessage_OutputsInvalidMove()
        {
            Tictactoe tictactoe = new Tictactoe();

            const string expected = "\nInvalid move!";
            string actual = tictactoe.OutputInvalidMoveMessage();

            Assert.Equal(expected, actual);
        }
    }
}
