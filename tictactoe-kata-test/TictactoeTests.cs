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

            const string expected = "\nWelcome to Tic Tac Toe!";
            string actual = tictactoe.WelcomeMessageOutput();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Tictactoe_CurrentBoardOutput_OutputsNewBoard()
        {
            Tictactoe tictactoe = new Tictactoe();
            const string expected = "\nHere's the current board:\n"
                + "\n"
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

        
        [Fact]
        public void Board_canCreateNewBoard_Creates3x3BoardWithEmptySpaces()
        {
            Board board = new Board();

            char[,] expected = {
                {'.','.','.'},
                {'.','.','.'},
                {'.','.','.'}};
                
            char[,] actual = board.Spaces;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Board_PlaceMarkerAt1_1_MarkerIsPlacedInCorrectPosition() //cant pass 2d =arrays as inline data!
        {
            Board board = new Board();

            board.PlaceMarkerAt(new int[]{1,1});

            char[,] expected = {
                {'X','.','.'},
                {'.','.','.'},
                {'.','.','.'}};
                
            char[,] actual = board.Spaces;

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Board_PlaceMarkerAt2_2_MarkerIsPlacedInCorrectPosition() //cant pass 2d =arrays as inline data!
        {
            Board board = new Board();

            board.PlaceMarkerAt(new int[]{2,2});

            char[,] expected = {
                {'.','.','.'},
                {'.','X','.'},
                {'.','.','.'}};
                
            char[,] actual = board.Spaces;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Board_PlaceMarkerAt3_3_MarkerIsPlacedInCorrectPosition() //cant pass 2d =arrays as inline data!
        {
            Board board = new Board();

            board.PlaceMarkerAt(new int[]{3,3});

            char[,] expected = {
                {'.','.','.'},
                {'.','.','.'},
                {'.','.','X'}};
                
            char[,] actual = board.Spaces;

            Assert.Equal(expected, actual);
        }
        
        //[Fact]
        //public void Board_UpdateBoard_UpdatesBoardWithSelectedCoords

        [Theory]
        [InlineData(InputAction.ValidMove, "\nMove accepted, here's the current board:\nHere's the current board:\n\n. . .\n. . .\n. . .")]
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
