using System;
namespace tictactoe_kata
{
    public class Board
    {
        public const int NumberOfRows = 3;
        public const int NumberOfCols = 3;
        public char[,] SpaceContents {get;} = new char[NumberOfRows, NumberOfCols]; //should this be private but have an accessor that takes coords as strings but returns the char at those coords?- discuss clean code

        public Board(){
            for (int i = 0; i < NumberOfRows; i++)
                for (int j = 0; j < NumberOfCols; j++)
                    SpaceContents[i,j] = '.';
        }

        public void PlaceMarkerAt(string coordsInput, PlayerMarker activePlayerMarker)
        {  
            SpaceContents[Coords.ParseRow(coordsInput), Coords.ParseCol(coordsInput)] = (char)activePlayerMarker; 
        }

        public bool SpaceIsTakenAt(string coordsInput)
        {
            if(SpaceContents[Coords.ParseRow(coordsInput),Coords.ParseCol(coordsInput)] != (char)PlayerMarker.None)      
                return true;
            else
                return false; 
        }

        public override string ToString()
        {
            string currentBoard = "\n";
            string[] rows = new string[NumberOfRows];
            
            for (int currentRow = 0; currentRow < NumberOfRows; currentRow++){
                string[] cols = new string[NumberOfCols];
                for (int currentCol = 0; currentCol < NumberOfCols; currentCol++){
                    cols[currentCol] = SpaceContents[currentRow,currentCol].ToString();
                }
            
                rows[currentRow] = string.Join(" ", cols);
            }
            currentBoard += string.Join("\n", rows);
            return currentBoard;
        }
    }
}