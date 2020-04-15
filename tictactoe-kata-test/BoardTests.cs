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

            board.PlaceMarkerAt("1,1");

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

            board.PlaceMarkerAt("2,2");

            char[,] expected = {
                {'.','.','.'},
                {'.','X','.'},
                {'.','.','.'}};
                
            char[,] actual = board.SpaceContents;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Board_PlaceMarkerAt3_3_MarkerIsPlacedInCorrectPosition() //cant pass 2d =arrays as inline data!
        {
            Board board = new Board();

            board.PlaceMarkerAt("3,3");

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
            board.PlaceMarkerAt("1,3");

            board.ToString();

            const string expected = "\n"
                + ". . X\n"
                + ". . .\n"
                + ". . .";
                
            string actual = board.ToString();

            Assert.Equal(expected, actual);
        }
    }
}