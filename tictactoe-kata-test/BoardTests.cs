using System;
using Xunit;
using tictactoe_kata;

namespace tictactoe_kata_test
{
    public class BoardTests
    {
                
        [Fact]
        public void Board_canCreateNewBoard_Creates3x3BoardWithEmptySpaces()
        {
            Board board = new Board();

            char[,] expected = {
                {'.','.','.'},
                {'.','.','.'},
                {'.','.','.'}};
                
            char[,] actual = board.SpaceContents;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Board_PlaceMarkerAt1_1_MarkerIsPlacedInCorrectPosition() //cant pass 2d =arrays as inline data!
        {
            Board board = new Board();

            board.PlaceMarkerAt("1,1", PlayerMarker.X);

            char[,] expected = {
                {'X','.','.'},
                {'.','.','.'},
                {'.','.','.'}};
                
            char[,] actual = board.SpaceContents;

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Board_PlaceMarkerAt2_2_MarkerIsPlacedInCorrectPosition() //cant pass 2d =arrays as inline data!
        {
            Board board = new Board();

            board.PlaceMarkerAt("2,2", PlayerMarker.O);

            char[,] expected = {
                {'.','.','.'},
                {'.','O','.'},
                {'.','.','.'}};
                
            char[,] actual = board.SpaceContents;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Board_PlaceMarkerAt3_3_MarkerIsPlacedInCorrectPosition() //cant pass 2d =arrays as inline data!
        {
            Board board = new Board();

            board.PlaceMarkerAt("3,3",PlayerMarker.X);

            char[,] expected = {
                {'.','.','.'},
                {'.','.','.'},
                {'.','.','X'}};
                
            char[,] actual = board.SpaceContents;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Board_ToString_NoMarkers_ReturnsEmptyBoardAsString() //cant pass 2d =arrays as inline data!
        {
            Board board = new Board();

            board.ToString();

            const string expected = "\n"
                + ". . .\n"
                + ". . .\n"
                + ". . .";
                
            string actual = board.ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Board_ToString_HasMarker_ReturnsBoardWithMarkerAsString_MarkerAtCorrectPosition() //cant pass 2d =arrays as inline data!
        {
            Board board = new Board();
            board.PlaceMarkerAt("1,3", PlayerMarker.X);

            board.ToString();

            const string expected = "\n"
                + ". . X\n"
                + ". . .\n"
                + ". . .";
                
            string actual = board.ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Board_SpaceIsTaken_ReturnsTrueIfSpaceIsAlreadyTaken() //cant pass 2d =arrays as inline data!
        {
            Board board = new Board();
            board.PlaceMarkerAt("1,3", PlayerMarker.O);

            Assert.True(board.SpaceIsTakenAt("1,3"));
        }

        [Fact]
        public void Board_SpaceIsTaken_ReturnsFalseIfSpaceIsEmpty() //cant pass 2d =arrays as inline data!
        {
            Board board = new Board();

            Assert.False(board.SpaceIsTakenAt("1,3"));
        }
    }
}